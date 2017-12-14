using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using UsersData.Models;

namespace UsersData
{
    public class DataSource : IDataSource
    {
        private string _sourceFileName;
        private string _dateFormat;

        public string DateFormat => _dateFormat;

        public DataSource(string sourceFileName = "Users.xml", string dateFormat = "yyyy-MM-dd")
        {
            _dateFormat = dateFormat;
            _sourceFileName = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{sourceFileName}";
        }

        public IEnumerable<UserModel> GetUsers()
        {
            IEnumerable<UserModel> userList = Enumerable.Empty<UserModel>();
            if ((new FileInfo(_sourceFileName)).Exists)
            {
                XDocument document = XDocument.Load(_sourceFileName);
                if (document != null)
                {
                    StringReader reader = new StringReader(document.Root.ToString());
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UserModel>), new XmlRootAttribute("ArrayOfUserModel"));
                    userList = (IEnumerable<UserModel>)xmlSerializer.Deserialize(reader);
                }
            }

            return userList;
        }

        public void SaveUsers(IEnumerable<UserModel> users)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UserModel>), new XmlRootAttribute("ArrayOfUserModel"));
            using (FileStream fs = new FileStream(_sourceFileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, users);
            }
        }
    }
}
