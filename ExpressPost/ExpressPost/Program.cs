using ExpressPost.Classes;
using ExpressPost.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost
{
    internal static class Program
    {
        // Створення статичного члена dataManager
        public static DB_DataManager DataManager { get; private set; }
        public static User CurrentUser { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Створення об'єкта DB_DataManager
                DataManager = new DB_DataManager();
                DBConnection.OpenConnection();
                // Виклик делегата для загрузки даних з бд в списки об'єктів класів
                DataManager.LoadData();

                CurrentUser = User.Load();
                if (CurrentUser != null)
                {
                    Form mainForm = new MainForm();// користувач уже авторизований, відкриваємо головне меню
                    FormProperties.SetToDefaultForm(mainForm);
                    Application.Run(mainForm);
                }
                else
                {
                    Form authorize = new AuthorizeForm();// користувач не авторизований, відкриваємо меню входу
                    FormProperties.SetToDefaultForm(authorize);
                    Application.Run(authorize);
                }
                DBConnection.CloseConnection();
            }
            catch (Exception ex)
            {
                // Виводимо повідомлення про помилку
                MessageBox.Show("Виникла помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
