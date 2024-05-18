using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost_CourseWork.Classes
{
    public abstract class User
    {
        private static string filePath = @"C:\Users\Owner\Desktop\labs\Second\CourseWork\ExpressPost_CourseWork\user.json";

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _password;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
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
        public string FullName
        {
            get { return FirstName + " " + LastName; }
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

        public User(string firstName, string lastName, string phoneNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public static User GetUserById(int id)
        {
            foreach (User user in Program.DataManager.Users)
            {
                if (user.Id == id)
                    return user;
            }
            return null;
        }

        //метод для збереження у файл інформації про авторизованого користувача
        public void Login()
        {
            // Перевіряємо, чи файл вже існує
            if (!File.Exists(filePath))
            {
                // Створюємо файл
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("{}"); // Записуємо порожній об'єкт JSON
                }
            }

            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, json);
        }

        //метод для загрузки інформації з файлу (якщо він існує)
        public static User Load()
        {
            string json = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(json))
                return null;

            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(json);

            User user = Program.DataManager.Users.FirstOrDefault(u => u.Id == userInfo.Id);
            return user;
        }

        //метод для виходу з акаунту тобто видалення файлу з інформацією
        public static void Logout()
        {
            // Перевіряємо, чи існує файл
            if (File.Exists(filePath))
                File.WriteAllText(filePath, String.Empty);
        }
    }
}
