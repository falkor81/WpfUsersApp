using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsersData.Models;

namespace TestUsersApp
{
    [TestClass()]
    public class UserModelTests
    {
        UserModel userA { get; set; }
        UserModel userB { get; set; }

        public UserModelTests()
        {
            userA = new UserModel()
            {
                FirstName = "FName",
                LastName = "LName",
                StreetName = "Street",
                HouseNumber = "House",
                ApartmentNumber = "Apartment",
                PostalCode = "12-345",
                PhoneNumber = "123-345-678",
                DayOfBirth = DateTime.Now.AddYears(-10)
            };
            userB = new UserModel()
            {
                FirstName = "FName",
                LastName = "LName",
                StreetName = "Street",
                HouseNumber = "House",
                //ApartmentNumber = "Apartment",
                PostalCode = "12-345",
                PhoneNumber = "123-345-678",
                DayOfBirth = DateTime.Now.AddYears(-10)
            };

        }

        [TestMethod]
        public void UserAgeTest()
        {
            Assert.IsNotNull(userA);
            Assert.AreEqual(userA.Age, 10);
        }

        [TestMethod]
        public void UserWithApartmentValidTest()
        {
            Assert.IsNotNull(userA);
            string errorMessage;
            Assert.IsTrue(userA.IsValid(out errorMessage));
        }

        [TestMethod]
        public void UserWithoutApartmentValidTest()
        {
            Assert.IsNotNull(userB);
            string errorMessage;
            Assert.IsTrue(userB.IsValid(out errorMessage));
        }
    }
}
