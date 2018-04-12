using RestSharp;
using RestSharp.Deserializers;
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
        //offline
        public Task<List<Zbozi>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Zbozi>("SELECT * FROM Zbozi");
        }
        //online
        public List<Zbozi> GetItemsRest()
        {
            var client = new RestClient(App.apiURL + "?getAllProducts");
            var request = new RestRequest(Method.GET);
            var response = client.Execute<List<Zbozi>>(request);

            JsonDeserializer deserializer = new JsonDeserializer();
            var data = deserializer.Deserialize<List<Zbozi>>(response);

            List<Zbozi> products = new List<Zbozi>();
            products = data;
            return products;
        }

        //offline
        public Task<List<Zbozi>> GetWhereCategoryIs(int kategorie)
        {
            return database.QueryAsync<Zbozi>("SELECT * FROM Zbozi WHERE KategorieZbozi = " + kategorie);
        }
        //online
        public List<Zbozi> GetWhereCategoryIsRest(int kategorie)
        {
            var client = new RestClient(App.apiURL + "?getProductsWhereCategoryIs");
            var request = new RestRequest(Method.GET);
            request.AddParameter("category", kategorie);
            var response = client.Execute<List<Zbozi>>(request);

            JsonDeserializer deserializer = new JsonDeserializer();
            var data = deserializer.Deserialize<List<Zbozi>>(response);

            List<Zbozi> products = new List<Zbozi>();
            products = data;
            return products;
        }

        public Task<List<Zbozi>> GetWhereID(int id)
        {
            return database.QueryAsync<Zbozi>("SELECT NazevZbozi FROM Zbozi WHERE ID = " + id);
        }

        // Query using LINQ
        public Task<Zbozi> GetItemAsync(string name)
        {
            return database.Table<Zbozi>().Where(i => i.NazevZbozi == name).FirstOrDefaultAsync();
        }

        // Query using LINQ
        //online
        public Task<Zbozi> GetItemAsyncByID(int id)
        {
            return database.Table<Zbozi>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        //offline
        public Zbozi GetItemByIDRest(int id)
        {
            var client = new RestClient(App.apiURL + "?GetWhereIDIs");
            var request = new RestRequest(Method.GET);
            request.AddParameter("productID", id);
            var response = client.Execute<Zbozi>(request);

            JsonDeserializer deserializer = new JsonDeserializer();
            var data = deserializer.Deserialize<Zbozi>(response);

            Zbozi products = new Zbozi();
            products = data;
            return products;
        }

        /*public Task<int> SaveItemAsync(Zbozi item) 
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }*/
        public Task<int> SaveItemAsync(Zbozi item)
        {

            return database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(Zbozi item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<Zbozi>> DeleteItemsFromTable()
        {
            return database.QueryAsync<Zbozi>("DELETE FROM Zbozi");
        }
    }
}
