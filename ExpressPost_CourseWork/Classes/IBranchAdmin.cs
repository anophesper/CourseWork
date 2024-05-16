using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost_CourseWork.Classes
{
    public interface IBranchAdmin
    {
        void MarkArrival(Parcel parcel);
        void MarkDeparture(Parcel parcel);
    }
}
