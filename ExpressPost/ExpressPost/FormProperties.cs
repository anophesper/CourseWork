using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost
{
    public class FormProperties
    {
        //private static Color mouseEnterColor = Color.Silver;
        //private static Color mouseDownColor = Color.FromArgb(224, 224, 224);

        /*public static void ApplyMouseProperties(Control control)
        {
            originalColor = control.BackColor;

            control.MouseEnter += (sender, e) =>
            {
                control.BackColor = mouseEnterColor;
            };

            control.MouseDown += (sender, e) =>
            {
                control.BackColor = mouseDownColor;
            };

            control.MouseUp += (sender, e) =>
            {
                control.BackColor = mouseEnterColor;
            };

            control.MouseLeave += (sender, e) =>
            {
                control.BackColor = originalColor;
            };
        }*/

        public static void SetToDefaultForm(Form form)
        {
            //відцентровали форму по цетру, налаштували розмір та стиль вікна
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Size = new Size(960, 540);
        }

        public static void AddExitButtonToForm(Form form)
        {
            PictureBox ExitBox = new PictureBox
            {
                Image = ExpressPost.Properties.Resources._4115230_cancel_close_delete_icon,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(30, 25),
                Location = new Point(930, 0)
            };
            ExitBox.Click += (sender, e) => { Application.Exit(); }; // додаємо обробник події Click
            //ExitBox.MouseEnter += (sender, e) => { ExitBox.Cursor = Cursors.Hand; }; // змінюємо курсор на "руку" при наведенні
            //ExitBox.MouseLeave += (sender, e) => { ExitBox.Cursor = Cursors.Default; }; // повертаємо курсор до стану за замовчуванням, коли він покидає область PictureBox
            form.Controls.Add(ExitBox); // додаємо ExitBox до форми
        }

        public static void SwitchToForm(Form currentForm, Form newForm)
        {
            SetToDefaultForm(newForm);
            currentForm.Hide();
            newForm.Show();
        }
    }
}
