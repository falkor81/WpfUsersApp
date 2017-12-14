using System.Collections.Generic;
using System.Threading.Tasks;
using UsersData;
using UsersData.Models;
using WpfUsersApp.Interfaces;

namespace WpfUsersApp.Services
{
    public interface IUsersRepository
    {
        IDataSource DataSource { get; }
        IEnumerable<UserModel> GetUsers(IDirty viewModel);
        void SaveUsers(ICollection<UserModel> users);
    }
}