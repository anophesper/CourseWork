using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class Branch
    {
        private int Id {  get; set; }
        private Cities City {  get; set; }
        private string _address;

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

        Branch(int id, Cities city, string address)
        {
            Id = id;
            City = city;
            Address = address;
        }
    }
}
