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
        public int cisloObjednavky { get; set; }
        public int typDopravy { get; set; } //1 == osobni odber, 2 == posta

        public override string ToString()
        {
            string doprava = "";
            if (typDopravy == 1)
            {
                doprava = "Osobní odběr v Praze";
            } else
            {
                doprava = "Poslat Českou poštou";
            }

            var getNazevZbozSQL = App.DatabazeZbozi.GetWhereID(IDzbozi).Result;

            return "Název zboží: " + getNazevZbozSQL[0].NazevZbozi + " | Množství zboží: " + mnozstviZbozi + " | Typ dopravy: " + doprava;
        }
    }
}
