﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class UserInfo
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _password;
        private string _role;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public UserInfo(int id, string firstName, string lastName, string phoneNumber, string password, string role)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _password = password;
            _role = role;
        }
    }
}