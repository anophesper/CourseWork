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
    public partial class SendPackages : BaseForm
    {
        //посилки на відправку
        public List<Parcel> sendPackages = Program.DataManager.Parcels.Where(parcel => parcel.IsConfirmedBranch && 
        parcel.CurrentBranch.Id != parcel.Route.Destination.Id).ToList();

        public SendPackages()
        {
            InitializeComponent();
        }
    }
}
