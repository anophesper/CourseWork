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

namespace ExpressPost_CourseWork.Forms.Client
{
    public partial class ClientMainForm : Form
    {
        public ClientMainForm()
        {
            InitializeComponent();
            FormProperties.DefaultFormSetup(this);
        }

        private void MyProfileButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new MyProfile());
        }

        private void CreateParcelButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new CreatePackageForm());
        }
    }
}
