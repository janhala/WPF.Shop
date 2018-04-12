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
    public class DatabazeObjednavkaZbozi
    {
        // SQLite connection
        private SQLiteAsyncConnection database;

        public DatabazeObjednavkaZbozi(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Objednavka>().Wait();
        }

        //online
        public void SaveItemRest(Objednavka_Zbozi item)
        {
            var restClient = new RestClient(App.apiURL + "?saveNewOrderProduct");
            var restRequest = new RestRequest(Method.POST);
            string json = JsonConvert.SerializeObject(item);
            restRequest.AddParameter("application/json", json, ParameterType.RequestBody);
            restRequest.RequestFormat = DataFormat.Json;
            var response = restClient.Execute(restRequest);
        }

        //online
        public List<Objednavka_Zbozi> GetWhereOrderIdRest(int orderID)
        {
            var client = new RestClient(App.apiURL + "?GetWhereOrderID");
            var request = new RestRequest(Method.GET);
            request.AddParameter("IDobjednavky", orderID);
            var response = client.Execute<List<Objednavka_Zbozi>>(request);

            JsonDeserializer deserializer = new JsonDeserializer();
            var data = deserializer.Deserialize<List<Objednavka_Zbozi>>(response);

            List<Objednavka_Zbozi> objednavka = new List<Objednavka_Zbozi>();
            objednavka = data;

            return objednavka;
        }
    }
}
