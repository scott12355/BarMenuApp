using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using BarMenuApp.Models;
using CsvHelper;
using CommunityToolkit.Maui.Core.Extensions;

namespace BarMenuApp.Services
{
    public class MenuRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection conn;
        

        private async Task Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Drink>();            
        }

        public MenuRepository(string dbPath)
        {
            _dbPath = dbPath;
            //PopulateMenu();
        }

        public async Task AddNewDrink(Drink newDrink)
        {
            int result = 0;
            try
            {
                await Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(newDrink.Name))
                    throw new Exception("Valid name required");

                // TODO: Insert the new person into the database
                if (conn.Table<Drink>().ToListAsync().Result.FirstOrDefault(x => x.id == newDrink.id) == null)
                {
                    result = await conn.InsertAsync(newDrink);
                }

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, newDrink.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", newDrink.Name, ex.Message);
            }

        }

        public async Task<List<Drink>> GetAllDrinks()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                await Init();
                return await conn.Table<Drink>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Drink>();
        }

        internal async Task RemoveDrink(Drink? item)
        {
            await Init();
            await conn.DeleteAsync(item);
        }
    }
}
