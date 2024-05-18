using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost_CourseWork.Classes
{
    public class Client : User
    {
        [JsonIgnore]
        public List<Parcel> Parcels { get; set; }

        public Client(string firstName, string lastName, string phoneNumber, string password) :
            base(firstName, lastName, phoneNumber, password)
        { }

        public Client(int id, string firstName, string lastName, string phoneNumber, string password) :
            base(id, firstName, lastName, phoneNumber, password)
        { }
    }
}
