using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Shop.Classes
{
    public class Zbozi
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NazevZbozi { get; set; }
        public int Cena { get; set; } // vypocet ceny bez DPH
        public int CenaPredSlevou { get; set; }
        public string Popis { get; set; }
        public int PocetKusuSkladem { get; set; }
        public int KategorieZbozi { get; set; } //id from Kategorie
        public int Vyprodej { get; set; } // 1 = vyprodej
        public string FotoZbozi { get; set; }
    }
}
