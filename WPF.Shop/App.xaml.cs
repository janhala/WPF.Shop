using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF.Shop.Database;

namespace WPF.Shop
{
    /// <summary>
    /// Interakční logika pro App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DatabazeKategorii _databazeKategorii;
        public static DatabazeKategorii DatabazeKategorii
        {
            get
            {
                if (_databazeKategorii == null)
                {
                    var fileHelper = new FileHelper();
                    _databazeKategorii = new DatabazeKategorii(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _databazeKategorii;
            }
        }

        private static DatabazeZbozi _databazeZbozi;
        public static DatabazeZbozi DatabazeZbozi
        {
            get
            {
                if (_databazeZbozi == null)
                {
                    var fileHelper = new FileHelper();
                    _databazeZbozi = new DatabazeZbozi(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _databazeZbozi;
            }
        }

        private static CartDatabase _cartDatabase;
        public static CartDatabase CartDatabase
        {
            get
            {
                if (_cartDatabase == null)
                {
                    var fileHelper = new FileHelper();
                    _cartDatabase = new CartDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _cartDatabase;
            }
        }
    }
}
