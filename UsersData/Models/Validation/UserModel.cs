using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersData.Models
{
    public partial class UserModel
    {
        public bool IsValid(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(FirstName))
            {
                errorMessage = Message("First Name");
            }
            else if (string.IsNullOrEmpty(LastName))
            {
                errorMessage = Message("Last Name");
                return false;
            }
            else if (string.IsNullOrEmpty(StreetName))
            {
                errorMessage = Message("Street Name");
                return false;
            }
            else if (string.IsNullOrEmpty(HouseNumber))
            {
                errorMessage = Message("House Number");
                return false;
            }
            else if (string.IsNullOrEmpty(PostalCode))
            {
                errorMessage = Message("Postal Code");
            }
            else if (string.IsNullOrEmpty(PhoneNumber))
            {
                errorMessage = Message("Phone Number");
            }
            else if (DayOfBirth == new DateTime())
            {
                errorMessage = Message("Day Of Birth");
            }

            return string.IsNullOrEmpty(errorMessage) ? true : false;
        }
    }
}
