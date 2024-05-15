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
    public partial class PickUpPackages : BaseForm
    {
        //посилки які мають видати 
        public List<Parcel> pickUpPackages = Program.DataManager.Parcels.Where(parcel => parcel.CurrentBranch.Id == parcel.Route.Destination.Id).ToList();

        public PickUpPackages()
        {
            InitializeComponent();
        }
    }
    //ЗМІНИТИ ТИП ДАНИХ ROUTE В КЛАСІ PARCEL НА ROUTE
}
