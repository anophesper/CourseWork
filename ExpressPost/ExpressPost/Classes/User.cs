using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExpressPost.Classes
{
    public abstract class User
    {
        private int Id;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _password;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Any(char.IsDigit) || value.Length < 2)
                    throw new Exception("Ім'я не може бути порожнім, містити цифри або бути коротшим за 2 символи");
                _firstName = value;
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Any(char.IsDigit) || value.Length < 2)
                    throw new Exception("Прізвище не може бути порожнім, містити цифри або бути коротшим за 2 символи");
                _lastName = value;
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (string.IsNullOrEmpty(value) || !value.All(char.IsDigit) || value.Length != 10)
                    throw new Exception("Телефонний номер повинен містити рівно 10 цифр і не містити інших символів");
                _phoneNumber = value;
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 8 || value.Contains(" "))
                    throw new Exception("Пароль повинен бути >= 8 символів і не містити пробіли");
                _password = value;
            }
        }

        public User(int id, string firstName, string lastName, string phoneNumber, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Password = password;
        }
    }
}
