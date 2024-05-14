using ExpressPost.Forms;
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
            form.Controls.Add(ExitBox); // додаємо ExitBox до форми
        }

        public static void AddBackButtonToForm(Form form)
        {
            // Перевіряємо, чи форма є одним з вказаних типів
            if (form is AuthorizeForm || form is ClientMainForm || form is BranchAdmMainForm || form is SystemAdmMainForm || form is RegistrationForm)
                return;

            // Створюємо нову кнопку "Назад"
            PictureBox BackBox = new PictureBox
            {
                Image = ExpressPost.Properties.Resources._172570_back_icon,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(23, 23),
                Location = new Point(0, 3) // Розташування відзеркалене від кнопки "Вихід"
            };

            // Додаємо обробник події Click, який закриває поточну форму
            BackBox.Click += (sender, e) => { SwitchToForm(form, Program.backForm); };

            // Додаємо BackBox до форми
            form.Controls.Add(BackBox);
        }

        public static void SwitchToForm(Form currentForm, Form newForm)
        {
            SetToDefaultForm(newForm);
            currentForm.Hide();
            Program.backForm = currentForm;
            newForm.Show();
        }
    }
}
