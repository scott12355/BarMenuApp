using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarMenuApp
{
    public class DbAccess : SQLiteConnection
    {
        public SQLiteConnection conn;
        public DbAccess(string databasePath, bool storeDateTimeAsTicks = true) : base(databasePath, storeDateTimeAsTicks)
        {
            conn = new SQLiteConnection(databasePath,Constants.Flags);
            InitializeDatabase();
        }

        

        public List<Drink> GetDrinks()
        {
            return conn.Table<Drink>().ToList();
        }

        bool TableExists<T>()
        {
            var tableInfo =  conn.GetTableInfo(typeof(T).Name);
            return tableInfo.Count > 0;
        }
        public void InitializeDatabase()
        {
            if (!TableExists<Drink>())
            {
                
                 conn.CreateTable<Drink>();
                Drink drink1 = new Drink(); drink1.Name = "Malibu and coke"; drink1.Description = "yum";
            //    conn.Insert(drink1);
                // Populate the table with initial data here (if needed)
            }
        }

    }
}
