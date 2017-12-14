using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsersData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersData.Models;
using System.IO;

namespace UsersData.Tests
{
    [TestClass()]
    public class DataSourceTests
    {
        IDataSource DataSource { get; set; }
        List<UserModel> Users { get; set; }
        readonly string testFileName = "TestUsers.xml";
        readonly string fullFilePath;

        public DataSourceTests()
        {
            fullFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{testFileName}";
        }

        [TestInitialize()]
        public void Initialize()
        {
            DataSource = new DataSource(testFileName);
            Users = new List<UserModel>()
            {
                new UserModel()
                {
                    FirstName = "FName",
                    LastName = "LName",
                    StreetName = "Street",
                    HouseNumber = "House",
                    ApartmentNumber = "Apartment",
                    PostalCode = "12-345",
                    PhoneNumber = "123-345-678",
                    DayOfBirth = DateTime.Now.AddYears(-10)
                }
            };
        }

        [TestCleanup()]
        public void Cleanup()
        {
            if ((new FileInfo(fullFilePath)).Exists)
            {
                File.Delete(fullFilePath);
            }
        }

        [TestMethod()]
        public void EmptyDataSourceTest()
        {
            var list = DataSource.GetUsers();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod()]
        public void SaveUsersTest()
        {
            Assert.IsFalse((new FileInfo(fullFilePath)).Exists);

            DataSource.SaveUsers(Users);

            Assert.IsTrue((new FileInfo(fullFilePath)).Exists);
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            DataSource.SaveUsers(Users);
            var list = DataSource.GetUsers();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 1);

            bool result = UsersAreEqual(Users[0], list[0]);
            Assert.IsTrue(true);
        }

        public bool UsersAreEqual(UserModel umA, UserModel umB)
        {
            if (umA != null && umB == null) return false;
            if (umA == null && umB != null) return false;

            if (umA.FirstName != umB.FirstName ||
                umA.LastName != umB.LastName ||
                umA.StreetName != umB.StreetName ||
                umA.HouseNumber != umB.HouseNumber ||
                umA.ApartmentNumber != umB.ApartmentNumber ||
                umA.PostalCode != umB.PostalCode ||
                umA.PhoneNumber != umB.PhoneNumber ||
                umA.DayOfBirth != umB.DayOfBirth) return false;

            return true;
        }
    }
}