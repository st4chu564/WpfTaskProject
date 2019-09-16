using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace WpfTaskProject.Classes {
    [Serializable]
    public class PersonalInfo : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }
        [XmlAttribute("LastName")]
        public string LastName { get; set; }
        [XmlAttribute("StreetName")]
        public string StreetName { get; set; }
        [XmlAttribute("HouseNumber")]
        public int HouseNumber { get; set; }
        [XmlAttribute("AparmentNumber")]
        public int? ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age {
            get {
                if(DateOfBirth == DateTime.MinValue) {
                    return 0;
                }
                else {
                    return DateTime.Today.Year - DateOfBirth.Year;
                }
            }
        }

        public PersonalInfo() {
            FirstName = "";
            LastName = "";
            StreetName = "";
            HouseNumber = 0;
            ApartmentNumber = null;
            PostalCode = "";
            PhoneNumber = "";
            DateOfBirth = DateTime.MinValue;
        }

        public PersonalInfo(string firstName, string lastName, string streetName, int houseNumber, int? apartmentNumber, string postalCode, string phoneNumber, DateTime dateOfBirth, int age) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
            this.ApartmentNumber = apartmentNumber;
            this.PostalCode = postalCode;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
        }


    }
}
