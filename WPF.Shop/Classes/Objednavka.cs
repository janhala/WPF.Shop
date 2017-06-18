using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Shop.Classes
{
    class Objednavka
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int CisloObjednavky { get; set; }
        public DateTime DatumObjednavky { get; set; }
        public int Stav { get; set; } // 1 == dorucena, 2 == zpracovava se, 3 == stornovana


    }
}
