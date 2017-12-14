using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UsersData.Models
{
    [Serializable()]
    [XmlRoot(ElementName = "UserDetails")]
    public partial class UserModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _streetName;
        private string _houseNumber;
        private string _apartmentNumber;
        private string _postalCode;
        private string _phoneNumber;
        private DateTime _dayOfBirth;

        private string Message(string fieldName) => $"{fieldName} must be filled.";

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [XmlAttribute("FirstName")]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }
        [XmlAttribute("LastName")]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }
        [XmlAttribute("StreetName")]
        public string StreetName
        {
            get
            {
                return _streetName;
            }
            set
            {
                if (_streetName != value)
                {
                    _streetName = value;
                    NotifyPropertyChanged("StreetName");
                }
            }
        }
        [XmlAttribute("HouseNumber")]
        public string HouseNumber
        {
            get
            {
                return _houseNumber;
            }
            set
            {
                if (_houseNumber != value)
                {
                    _houseNumber = value;
                    NotifyPropertyChanged("HouseNumber");
                }
            }
        }
        [XmlAttribute("ApartmentNumber")]
        public string ApartmentNumber
        {
            get
            {
                return _apartmentNumber;
            }
            set
            {
                if (_apartmentNumber != value)
                {
                    _apartmentNumber = value;
                    NotifyPropertyChanged("ApartmentNumber");
                }
            }
        }
        [XmlAttribute("PostalCode")]
        public string PostalCode
        {
            get
            {
                return _postalCode;
            }
            set
            {
                if (_postalCode != value)
                {
                    _postalCode = value;
                    NotifyPropertyChanged("PostalCode");
                }
            }
        }
        [XmlAttribute("PhoneNumber")]
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    NotifyPropertyChanged("PhoneNumber");
                }
            }
        }
        [XmlAttribute("DayOfBirth")]
        public DateTime DayOfBirth
        {
            get
            {
                return _dayOfBirth;
            }
            set
            {
                if (_dayOfBirth != value)
                {
                    _dayOfBirth = value;
                    NotifyPropertyChanged("DayOfBirth");
                    NotifyPropertyChanged("Age");
                }
            }
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DayOfBirth.Year;
            }
        }

        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
