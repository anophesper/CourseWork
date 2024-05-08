using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost
{
    //патерн спостерігач: реагує на зміни в базі даних і автоматично оновлює списки об’єктів, коли відбуваються зміни
    public class DatabaseObserver
    {
        private DB_DataManager dataManager;

        public DatabaseObserver(DB_DataManager dataManager) { this.dataManager = dataManager; }

        public void OnDatabaseChanged() { dataManager.LoadData(); }
    }
}
