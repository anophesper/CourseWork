using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost.Classes
{
    internal interface IBranchAdmin
    {
        void MarkArrival(Parcel parcel);
        void MarkDeparture(Parcel parcel);
    }
}
