using Newtonsoft.Json;
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

        //offline
        public Task<List<Uzivatel>> GetAllIDs()
        {
            return database.QueryAsync<Uzivatel>("SELECT ID FROM Uzivatel ORDER BY ID DESC");
        }
        //online
        public List<Uzivatel> GetAllIDsRest()
        {
            var client = new RestClient(App.apiURL + "?GetAllIDs");
            var request = new RestRequest(Method.GET);
            var response = client.Execute<List<Uzivatel>>(request);

            List<Uzivatel> ids = null;
            if (response.Data != null)
            {
                JsonDeserializer deserializer = new JsonDeserializer();
                var data = deserializer.Deserialize<List<Uzivatel>>(response);

                ids = new List<Uzivatel>();
                ids = data;
            }
            
            return ids;
        }

        // Query using LINQ
        public Task<Uzivatel> GetItemAsync(int id)
        {
            return database.Table<Uzivatel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        //offline
        public Task<int> SaveItemAsync(Uzivatel item)
        {
            return database.InsertAsync(item);
        }
        //online
        public void SaveItemRest(Uzivatel item)
        {
            var restClient = new RestClient(App.apiURL + "?saveNewUser");
            var restRequest = new RestRequest(Method.POST);
            string json = JsonConvert.SerializeObject(item);
            restRequest.AddParameter("application/json", json, ParameterType.RequestBody);
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute(restRequest);
        }

        public Task<int> DeleteItemAsync(Uzivatel item)
        {
            return database.DeleteAsync(item);
        }

        //offline
        public Task<List<Uzivatel>> CheckPIN(int orderNumber)
        {
            return database.QueryAsync<Uzivatel>("SELECT PIN FROM Uzivatel INNER JOIN Objednavka ON Objednavka.IDuzivatele = Uzivatel.ID WHERE CisloObjednavky = " + orderNumber + " LIMIT 1");
        }
        //online
        public List<Uzivatel> CheckPINRest(int orderNumber)
        {
            var client = new RestClient(App.apiURL + "?CheckPIN");
            var request = new RestRequest(Method.GET);
            var response = client.Execute<List<Uzivatel>>(request);

            JsonDeserializer deserializer = new JsonDeserializer();
            var data = deserializer.Deserialize<List<Uzivatel>>(response);

            List<Uzivatel> usersPinList = new List<Uzivatel>();
            usersPinList = data;

            return usersPinList;
        }
    }
}
