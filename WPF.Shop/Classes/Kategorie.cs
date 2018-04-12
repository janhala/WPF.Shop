using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Shop.Classes
{
    public class Kategorie
    {
        //[PrimaryKey, AutoIncrement]
        [PrimaryKey]
        public int ID { get; set; }
        public string NazevKategorie { get; set; }

        public Kategorie()
        {
        }
        public override string ToString()
        {
            return "ID" + ID + " Name " + NazevKategorie;
        }
    }
}
