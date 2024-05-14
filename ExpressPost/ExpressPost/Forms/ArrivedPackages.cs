using ExpressPost.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost.Forms
{
    public partial class ArrivedPackages : BaseForm
    {
        //посилки які треба підтвердити що вони на відділенні (створені накладні та прибувші на відділення)
        public List<Parcel> arrivedPackages = Program.DataManager.Parcels.Where(parcel => !parcel.IsConfirmedBranch).ToList();

        public ArrivedPackages()
        {
            InitializeComponent();
        }
    }
}
