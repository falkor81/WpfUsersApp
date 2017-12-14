﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using UsersData.Models;

namespace WpfUsersApp.Users
{
    class UserValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            UserModel user = (value as BindingGroup).Items[0] as UserModel;

            string errorMessage;
            ValidationResult result = user.IsValid(out errorMessage) ? ValidationResult.ValidResult : new ValidationResult(false, errorMessage);
            return result;
        }
    }
}
