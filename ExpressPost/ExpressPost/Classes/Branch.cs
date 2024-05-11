using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class Branch
    {
        private int _id {  get; set; }
        private Cities _city {  get; set; }
        private string _address;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Cities City
        {
            get { return _city; }
            set
            {
                if (!Enum.IsDefined(typeof(Cities), value))
                    throw new ArgumentException("Недопустиме значення для поля Місто");
                _city = value;
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Поле Адреса не може бути порожнім");
                _address = value;
            }
        }

        public Branch(int id, Cities city, string address)
        {
            Id = id;
            City = city;
            Address = address;
        }
    }
}
