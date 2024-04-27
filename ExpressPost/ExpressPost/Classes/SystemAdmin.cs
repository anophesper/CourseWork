using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class SystemAdmin : User
    {
        public SystemAdmin(int id, string firstName, string lastName, string phoneNumber, string password) : 
            base(id, firstName, lastName, phoneNumber, password){}
    }
}
