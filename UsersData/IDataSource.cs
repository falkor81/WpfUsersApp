using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UsersData.Models;

namespace UsersData
{
    public interface IDataSource
    {
        string DateFormat { get; }

        IEnumerable<UserModel> GetUsers();
        void SaveUsers(IEnumerable<UserModel> users);
    }
}
