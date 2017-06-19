using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Shop.Classes
{
    public class Kosik
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int IDzbozi { get; set; }
        public string NazevZbozi { get; set; }
        public int Cena { get; set; }
        public int Mnozstvi { get; set; }
    }
}
