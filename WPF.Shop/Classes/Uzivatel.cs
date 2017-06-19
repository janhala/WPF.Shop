using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Shop.Classes
{
    public class Uzivatel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public Int32 PIN { get; set; }
        public Int32 Telefon { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string UliceCP { get; set; }
        public string Obec { get; set; }
        public Int32 PSC { get; set; }

    }
}
