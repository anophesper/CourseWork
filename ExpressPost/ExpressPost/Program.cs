using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // Створення об'єкта для змоги підключення до бази даних
            DBConnection dbConnection = new DBConnection();
            // Створення об'єкта DB_DataManager
            DB_DataManager dataManager = new DB_DataManager(dbConnection);
            // Виклик делегата для загрузки даних з бд в списки об'єктів класів
            dataManager.LoadData();
        }
    }
}
