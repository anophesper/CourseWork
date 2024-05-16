using ExpressPost_CourseWork.Forms.Authorize;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost_CourseWork.Forms.BranchAdmin
{
    public partial class BranchAdmMainForm : Form
    {
        public BranchAdmMainForm()
        {
            InitializeComponent();
            FormProperties.DefaultFormSetup(this);
        }

        private void MyProfileButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new MyProfile());
        }

        private void ArrivedParcelButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new ArrivedPackages());
        }

        private void SendParcelButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new SendPackages());
        }

        private void PickUpParcelButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new PickUpPackages());
        }
    }
}
