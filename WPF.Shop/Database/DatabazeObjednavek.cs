﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<int> SaveItemAsync(Objednavka item)
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

        public Task<int> DeleteItemAsync(Objednavka item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<Objednavka>> GetWhereOrderNumber(int orderNumber)
        {
            return database.QueryAsync<Objednavka>("SELECT * FROM Objednavka WHERE cisloObjednavky = " + orderNumber);
        }

        public Task<List<Objednavka>> StornovatObjednavku(int orderNumber)
        {
            return database.QueryAsync<Objednavka>("DELETE FROM Objednavka WHERE cisloObjednavky = " + orderNumber);
        }
    }
}
