using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Shop.Classes;

namespace WPF.Shop.Database
{
    public class DatabazeKategorii
    {
        // SQLite connection
        private SQLiteAsyncConnection database;

        public DatabazeKategorii(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Kategorie>().Wait();
        }

        // Query
        public Task<List<Kategorie>> GetItemsAsync()
        {
            return database.Table<Kategorie>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Kategorie>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Kategorie>("SELECT * FROM Kategorie");
        }

        // Query using LINQ
        public Task<Kategorie> GetItemAsync(int id)
        {
            return database.Table<Kategorie>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Kategorie item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Kategorie item)
        {
            return database.DeleteAsync(item);
        }
    }
}
