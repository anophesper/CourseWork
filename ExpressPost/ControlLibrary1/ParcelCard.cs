using ExpressPost;
using ExpressPost.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlLibrary1
{
    public partial class ParcelCard : UserControl
    {
        public ParcelCard(Parcel parcel)
        {
            InitializeComponent();
            this.BackColor = Color.LightGray;//фон картки
            billOfLadingLabel.Text = parcel.BillOfLading;
            data1Label.Text = parcel.DeliveryTime.ToString();
            data2Label.Text = parcel.DispatchTime.ToString();
            city1Label.Text = parcel.Route.Origin.City.ToString();
            city2Label.Text = parcel.Route.Destination.City.ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
