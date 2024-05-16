using ExpressPost_CourseWork.Forms.Authorize;
using ExpressPost_CourseWork.Forms.BranchAdmin;
using ExpressPost_CourseWork.Forms.Client;
using ExpressPost_CourseWork.Forms.SystemAdmin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost_CourseWork
{
    //делегат для налаштування форм 
    public delegate void FormSetupDelegate(Form form);

    public class FormProperties
    {
        public static FormSetupDelegate DefaultFormSetup = (form) =>
        {
            SetToDefaultForm(form);
            AddExitButtonToForm(form);
            AddBackButtonToForm(form);
        };

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
                Image = Properties.Resources._4115230_cancel_close_delete_icon,
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
                Image = Properties.Resources._172570_back_icon,
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
