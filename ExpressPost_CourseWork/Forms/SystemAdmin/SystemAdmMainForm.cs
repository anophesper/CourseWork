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

namespace ExpressPost_CourseWork.Forms.SystemAdmin
{
    public partial class SystemAdmMainForm : Form
    {
        public SystemAdmMainForm()
        {
            InitializeComponent();
            FormProperties.DefaultFormSetup(this);
        }

        private void MyProfileButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new MyProfile());
        }

        private void WorkersButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new WorkersForm());
        }

        private void BranchesButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new BranchesForm());
        }

        private void RoutesButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new RoutesForm());
        }
    }
}
