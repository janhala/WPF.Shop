using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WPF.Shop.Classes;

namespace WPF.Shop.Database
{
    public class DatabazeObjednavek
    {
        // SQLite connection
        private SQLiteAsyncConnection database;

        public DatabazeObjednavek(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Objednavka>().Wait();
        }

        // Query
        public Task<List<Objednavka>> GetItemsAsync()
        {
            return database.Table<Objednavka>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Objednavka>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Objednavka>("SELECT * FROM Objednavka");
        }

        public Task<List<Objednavka>> CheckIfOrderNumberExist(int orderNumber)
        {
            return database.QueryAsync<Objednavka>("SELECT cisloObjednavky FROM Objednavka WHERE cisloObjednavky = " + orderNumber);
        }

        // Query using LINQ
        public Task<Objednavka> GetItemAsync(int id)
        {
            return database.Table<Objednavka>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        //offline
        public Task<int> SaveItemAsync(Objednavka item)
        {
            return database.InsertAsync(item);
        }
        //online
        public void SaveItemRest(Objednavka item)
        {
            var restClient = new RestClient(App.apiURL + "?saveNewOrder");
            var restRequest = new RestRequest(Method.POST);
            string json = JsonConvert.SerializeObject(item);
            restRequest.AddParameter("application/json", json, ParameterType.RequestBody);
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute(restRequest);
        }

        public Task<int> DeleteItemAsync(Objednavka item)
        {
            return database.DeleteAsync(item);
        }

        //offline
        public Task<List<Objednavka>> GetWhereOrderNumber(int orderNumber)
        {
            return database.QueryAsync<Objednavka>("SELECT * FROM Objednavka WHERE cisloObjednavky = " + orderNumber);
        }
        //online
        public List<Objednavka> GetWhereOrderNumberRest(int orderNumber)
        {
            var client = new RestClient(App.apiURL + "?GetWhereOrderNumber");
            var request = new RestRequest(Method.GET);
            request.AddParameter("cisloObjednavky", orderNumber);
            var response = client.Execute<List<Objednavka>>(request);

            JsonDeserializer deserializer = new JsonDeserializer();
            var data = deserializer.Deserialize<List<Objednavka>>(response);

            List<Objednavka> objednavka = new List<Objednavka>();
            objednavka = data;

            return objednavka;
        }

        //offline
        public Task<List<Objednavka>> StornovatObjednavku(int orderNumber)
        {
            return database.QueryAsync<Objednavka>("DELETE FROM Objednavka WHERE cisloObjednavky = " + orderNumber);
        }
        //online
        public List<Objednavka> StornovatObjednavkuRest(int orderNumber)
        {
            var client = new RestClient(App.apiURL + "?StornovatObjednavku");
            var request = new RestRequest(Method.DELETE);
            request.AddParameter("cisloObjednavky", orderNumber);
            var response = client.Execute<List<Objednavka>>(request);

            JsonDeserializer deserializer = new JsonDeserializer();
            var data = deserializer.Deserialize<List<Objednavka>>(response);

            List<Objednavka> objednavka = new List<Objednavka>();
            objednavka = data;

            return objednavka;
        }
    }
}
