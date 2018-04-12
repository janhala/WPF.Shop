using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Shop.Classes
{
    public class Objednavka_Zbozi
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int IDobjednavky { get; set; }
        public int IDzbozi { get; set; }
        public int mnozstviZbozi { get; set; }
    }
}
