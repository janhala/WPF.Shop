using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Shop.Classes
{
    class Uzivatel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Heslo { get; set; }
        public int Telefon { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string UliceCP { get; set; }
        public string Obec { get; set; }
        public int PSC { get; set; }

    }
}
