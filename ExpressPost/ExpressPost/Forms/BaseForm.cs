using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost.Forms
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            FormProperties.SetToDefaultForm(this);
            FormProperties.AddExitButtonToForm(this);
            FormProperties.AddBackButtonToForm(this);
            // Інші налаштування форми...
        }
    }
}
