using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    public class BranchAdmin : User
    {
        private Branch _branch;

        public Branch Branch
        {
            get => _branch;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Branch), "Відділення має бути вказаним");
                _branch = value;
            }
        }

        public BranchAdmin(int id, string firstName, string lastName, string phoneNumber, string password, Branch branch) :
            base(id, firstName, lastName, phoneNumber, password)
        {
            Branch = branch;
        }
    }

}
