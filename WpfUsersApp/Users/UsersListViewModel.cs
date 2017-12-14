using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UsersData;
using UsersData.Models;
using WpfUsersApp.Interfaces;
using WpfUsersApp.Services;

namespace WpfUsersApp.Users
{
    public class UsersListViewModel : IDirty, INotifyPropertyChanged
    {
        private IUsersRepository _usersRepository;
        private ObservableCollection<UserModel> _users;
        private UserModel _user;
        private bool _isCollectionDirty;

        private static bool IsInDesignerMode => DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());

        private void RefreshUsersCollection()
        {
            Users = null;
            Users = new ObservableCollection<UserModel>(_usersRepository.GetUsers(this));
            _isCollectionDirty = false;
            if (SaveCommand != null)
            {
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public UsersListViewModel() : this(new UsersRepository(new DataSource()))
        {
        }

        public UsersListViewModel(IUsersRepository usersRepository)
        {
            if (IsInDesignerMode) return;

            _usersRepository = usersRepository;

            RefreshUsersCollection();

            SaveCommand = new RelayCommand(OnSave, CanSave);
            Users.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add ||
                    e.Action == NotifyCollectionChangedAction.Remove)
                {
                    _isCollectionDirty = true;
                    SaveCommand.RaiseCanExecuteChanged();
                }
            };

            RefreshCommand = new RelayCommand(OnRefresh, () => true);
        }

        public RelayCommand SaveCommand { get; private set; }

        public RelayCommand RefreshCommand { get; private set; }

        public ObservableCollection<UserModel> Users
        {
            get
            {
                return _users;
            }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    NotifyPropertyChanged("Users");
                }
            }
        }

        public UserModel SelectedUser
        {
            get
            {
                return _user;
            }
            set
            {
                if (_user != value)
                {
                    _user = value;
                }
            }
        }

        public void PropertyDirty(object sender, PropertyChangedEventArgs e)
        {
            _isCollectionDirty = true;
            SaveCommand.RaiseCanExecuteChanged();
        }

        public void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region RefreshData
        private void OnRefresh()
        {
            RefreshUsersCollection();
        }
        #endregion

        #region SaveData
        private void OnSave()
        {
            _usersRepository.SaveUsers(_users.ToList());
            _isCollectionDirty = false;
            SaveCommand.RaiseCanExecuteChanged();
        }

        private bool CanSave()
        {
            string errorMessage;
            bool result = SelectedUser?.IsValid(out errorMessage) == true ? _isCollectionDirty : false;
            return result;
        }
        #endregion
    }
}
