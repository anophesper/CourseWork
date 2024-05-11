using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class Client : User
    {
        public List<ParcelGroup> Parcels { get; set; }

        public Client(string firstName, string lastName, string phoneNumber, string password) :
            base(firstName, lastName, phoneNumber, password) { }

        public Client(int id, string firstName, string lastName, string phoneNumber, string password) :
            base(id, firstName, lastName, phoneNumber, password) { }

        public Client(int id, string firstName, string lastName, string phoneNumber, string password, List<ParcelGroup> parcels) : 
            base(id, firstName, lastName, phoneNumber, password)
        {
            Parcels = parcels;
        }
    }
}
