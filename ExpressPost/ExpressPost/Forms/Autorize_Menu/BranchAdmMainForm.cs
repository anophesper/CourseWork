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
    public partial class BranchAdmMainForm : BaseForm
    {
        public BranchAdmMainForm()
        {
            InitializeComponent();
        }

        private void MyProfile_button_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new MyProfile());
        }

        private void CreatePackageButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new CreatePackageForm());
        }

        //посилки які треба підтвердити що вони на відділенні (створені накладні та прибувші на відділення)
        private void arrivedPackages_button_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new ArrivedPackages());
        }

        //посилки які мають видати 
        private void pickUpParcels_button_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new PickUpPackages());
        }

        //посилки на відправку
        private void sendPackages_button_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new SendPackages());
        }
    }
}
