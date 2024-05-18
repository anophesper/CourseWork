using ExpressPost_CourseWork.Classes;
using ExpressPost_CourseWork.Forms.Authorize;
using ExpressPost_CourseWork.Forms.BranchAdmin;
using ExpressPost_CourseWork.Forms.Client;
using ExpressPost_CourseWork.Forms.SystemAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost_CourseWork
{
    internal static class Program
    {
        // Створення статичного члена dataManager
        public static DB_DataManager DataManager { get; private set; }
        public static User CurrentUser { get; set; }
        public static Form backForm { get; set; }

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
                DB_DataManager.LoadData();

                CurrentUser = User.Load();
                if (CurrentUser != null)
                {
                    Form mainForm = new ClientMainForm(); // Оголошуємо змінну для головної форми

                    // Визначаємо тип користувача і відкриваємо відповідну форму
                    switch (CurrentUser)
                    {
                        case Client client:
                            mainForm = new ClientMainForm();
                            break;
                        case BranchAdmin branchAdmin:
                            mainForm = new BranchAdmMainForm();
                            break;
                        case SystemAdmin systemAdmin:
                            mainForm = new SystemAdmMainForm();
                            break;
                        default:
                            throw new Exception("Невідомий тип користувача");
                    }

                    FormProperties.SetToDefaultForm(mainForm); // Встановлюємо властивості форми за замовчуванням
                    Application.Run(mainForm); // Запускаємо головну форму
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
