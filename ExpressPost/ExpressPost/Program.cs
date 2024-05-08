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
        public static DB_DataManager dataManager { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Створення об'єкта для змоги підключення до бази даних
            DBConnection dbConnection = new DBConnection();
            // Створення об'єкта DB_DataManager
            dataManager = new DB_DataManager(dbConnection);
            // Виклик делегата для загрузки даних з бд в списки об'єктів класів
            dataManager.LoadData();

            User user = User.Load();
            if (user != null)
                Application.Run(new MainForm());// користувач уже авторизований, відкриваємо головне меню
            else
                Application.Run(new AuthorizeForm());// користувач не авторизований, показуємо форму авторизації*/
        }
    }
}
