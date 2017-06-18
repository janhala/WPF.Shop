using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Shop.Classes;

namespace WPF.Shop.Database
{
    public class DatabazeZbozi
    {
        // SQLite connection
        private SQLiteAsyncConnection database;

        public DatabazeZbozi(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Zbozi>().Wait();
        }

        // Query
        public Task<List<Zbozi>> GetItemsAsync()
        {
            return database.Table<Zbozi>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Zbozi>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Zbozi>("SELECT * FROM Zbozi");
        }

        public Task<List<Zbozi>> GetWhereCategoryIs(int kategorie)
        {
            return database.QueryAsync<Zbozi>("SELECT * FROM Zbozi WHERE KategorieZbozi = " + kategorie);
        }

        // Query using LINQ
        public Task<Zbozi> GetItemAsync(string name)
        {
            return database.Table<Zbozi>().Where(i => i.NazevZbozi == name).FirstOrDefaultAsync();
        }

        // Query using LINQ
        public Task<Zbozi> GetItemAsyncByID(int id)
        {
            return database.Table<Zbozi>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Zbozi item)
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

        public Task<int> DeleteItemAsync(Zbozi item)
        {
            return database.DeleteAsync(item);
        }
    }
}
