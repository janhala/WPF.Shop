using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WPF.Shop.Classes
{
    public class Objednavka
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } //slouzi jako CISLO OBJEDNAVKY
        public int IDuzivatele { get; set; }
        public int IDzbozi { get; set; }
        public int mnozstviZbozi { get; set; }
    }
}
