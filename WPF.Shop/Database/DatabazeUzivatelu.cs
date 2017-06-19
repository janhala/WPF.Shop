using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Shop.Classes;

namespace WPF.Shop.Database
{
    public class DatabazeUzivatelu
    {
        // SQLite connection
        private SQLiteAsyncConnection database;

        public DatabazeUzivatelu(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Uzivatel>().Wait();
        }

        // Query
        public Task<List<Uzivatel>> GetItemsAsync()
        {
            return database.Table<Uzivatel>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Uzivatel>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Uzivatel>("SELECT * FROM Uzivatel");
        }

        public Task<List<Uzivatel>> GetWhereEmail(string email)
        {
            return database.QueryAsync<Uzivatel>("SELECT * FROM Uzivatel WHERE Email = " + email);
        }

        public Task<List<Uzivatel>> GetAllIDs()
        {
            return database.QueryAsync<Uzivatel>("SELECT ID FROM Uzivatel");
        }

        // Query using LINQ
        public Task<Uzivatel> GetItemAsync(int id)
        {
            return database.Table<Uzivatel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Uzivatel item)
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

        public Task<int> DeleteItemAsync(Uzivatel item)
        {
            return database.DeleteAsync(item);
        }
    }
}
