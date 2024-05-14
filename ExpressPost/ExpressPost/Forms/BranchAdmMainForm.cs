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
    }
}
