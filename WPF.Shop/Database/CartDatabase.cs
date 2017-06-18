using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Shop.Classes;

namespace WPF.Shop.Database
{
    public class CartDatabase
    {
        // SQLite connection
        private SQLiteAsyncConnection database;

        public CartDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Kosik>().Wait();
        }

        // Query
        public Task<List<Kosik>> GetItemsAsync()
        {
            return database.Table<Kosik>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Kosik>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Kosik>("SELECT * FROM Kosik");
        }

        // Query using LINQ
        public Task<Kosik> GetItemAsync(int id)
        {
            return database.Table<Kosik>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Kosik item)
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

        public Task<List<Kosik>> AktualizovatPocetKusuZbozi(int id)
        {
            return database.QueryAsync<Kosik>("UPDATE Kosik SET Mnozstvi = Mnozstvi + 1 WHERE ID = " + id );
        }

        public Task<List<Kosik>> GetbyID(int id)
        {
            return database.QueryAsync<Kosik>("SELECT * FROM Kosik WHERE ID = " + id);
        }

        public Task<int> DeleteItemAsync(Kosik item)
        {
            return database.DeleteAsync(item);
        }
    }
}
