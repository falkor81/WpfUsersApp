using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UsersData;
using UsersData.Models;
using WpfUsersApp.Interfaces;

namespace WpfUsersApp.Services
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDataSource _dataSource;

        private static bool IsInDesignerMode => DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());

        public IDataSource DataSource => _dataSource;

        public UsersRepository(IDataSource dataSource)
        {
            _dataSource = dataSource;

            if (IsInDesignerMode) return;
        }

        public IEnumerable<UserModel> GetUsers(IDirty viewModel)
        {
            IEnumerable<UserModel> users = _dataSource.GetUsers();

            foreach(UserModel user in users)
            {
                user.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(viewModel.PropertyDirty);
            }

            return users;
        }

        public void SaveUsers(ICollection<UserModel> users)
        {
            _dataSource.SaveUsers(users);
        }
    }
}
