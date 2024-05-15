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
    public partial class SystemAdmMainForm : BaseForm
    {
        public SystemAdmMainForm()
        {
            InitializeComponent();
        }

        private void MyProfile_button_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new MyProfile());
        }

        private void WorkersButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new WorkersForm());
        }

        private void routesButton_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new RoutesForm());
        }
    }
}
