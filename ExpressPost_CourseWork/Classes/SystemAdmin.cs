using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost_CourseWork.Classes
{
    public class SystemAdmin : User
    {
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public SystemAdmin(int id, string firstName, string lastName, string phoneNumber, string password) :
            base(id, firstName, lastName, phoneNumber, password)
        { }

        public SystemAdmin(string firstName, string lastName, string phoneNumber, string password) :
            base(firstName, lastName, phoneNumber, password)
        { }
    }
}
