using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Shop.Classes;
using WPF.Shop.Database;
using WPF.Shop.Pages;

namespace WPF.Shop
{
    /// <summary>
    /// Interakční logika pro Cart.xaml
    /// </summary>
    public partial class Cart : Page
    {
        public int doprava { get; set; }
        public List<int> zboziObjednavky { get; set; }
        public List<int> mnozstviZbozi { get; set; }
        public Cart(List<int> kosik)
        {
            InitializeComponent();

            int soucetCen = 0;
            List<int> zboziObjednavkyList = new List<int>();
            List<int> mnozstviZboziList = new List<int>();

            if (kosik.Count > 1)
            {
                foreach (int idZbozi in kosik)
                {
                    int idZboziExist = App.CartDatabase.GetbyID(idZbozi).Result.Count();
                    if (idZboziExist < 1)
                    {
                        var queryofItems = App.DatabazeZbozi.GetItemAsyncByID(idZbozi).Result;

                        Kosik cart = new Kosik();
                        cart.IDzbozi = queryofItems.ID;
                        cart.NazevZbozi = queryofItems.NazevZbozi;
                        cart.Cena = queryofItems.Cena;
                        cart.Mnozstvi = 1;
                        App.CartDatabase.SaveItemAsync(cart);

                        if (soucetCen == 0)
                        {
                            soucetCen = queryofItems.Cena;
                        }
                        else
                        {
                            soucetCen = queryofItems.Cena + soucetCen;
                        }
                    }
                    else
                    {
                        App.CartDatabase.AktualizovatPocetKusuZbozi(idZbozi);

                        var queryofItems = App.DatabazeZbozi.GetItemAsyncByID(idZbozi).Result;
                        if (soucetCen == 0)
                        {
                            soucetCen = queryofItems.Cena;
                        }
                        else
                        {
                            soucetCen = queryofItems.Cena + soucetCen;
                        }
                    }

                    zboziObjednavkyList.Add(idZbozi);
                }
            } else {
                var queryCart = App.CartDatabase.GetItemsAsync().Result;

                foreach (Kosik cart in queryCart)
                {
                    if (soucetCen == 0)
                    {
                        soucetCen = cart.Cena;
                    }
                    else
                    {
                        soucetCen = cart.Cena + soucetCen;
                    }

                    zboziObjednavkyList.Add(cart.IDzbozi);
                }

                    CartLV.ItemsSource = queryCart;
            }
            
            celkovaCena.Content = "Celková cena objednávky je " + soucetCen.ToString() + " Kč.";

            zboziObjednavky = zboziObjednavkyList;
        }

        private void CartLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OdstranitZeSeznamu(object sender, RoutedEventArgs e)
        {
            //Zbozi zbozi = new Zbozi();
            int zboziKeSmazani = (int)(e.Source as Button).Tag;
            App.CartDatabase.OdstranitZbozi(zboziKeSmazani);
        }

        private void DopravaCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (DopravaCheckBoxCP.IsChecked == false)
            {
                int x = 0;
                Int32.TryParse(DopravaCheckBox.Tag.ToString(), out x);
                doprava = x;
            } else
            {
                DopravaCheckBoxCP.IsChecked = false;

                int x = 0;
                Int32.TryParse(DopravaCheckBox.Tag.ToString(), out x);
                doprava = x;
            }
        }

        private void DopravaCheckBoxCP_Checked(object sender, RoutedEventArgs e)
        {
            if (DopravaCheckBox.IsChecked == false)
            {
                int x = 0;
                Int32.TryParse(DopravaCheckBox.Tag.ToString(), out x);
                doprava = x;
            } else
            {
                DopravaCheckBox.IsChecked = false;

                int x = 0;
                Int32.TryParse(DopravaCheckBox.Tag.ToString(), out x);
                doprava = x;
            }
        }

        private void SaveOrder(object sender, RoutedEventArgs e)
        {
            /*string mail;

            var selectWhereMail = App.DatabazeUzivatelu.GetWhereEmail(email.Text).Result;
            if (selectWhereMail.Count > 0)
            {
                selectWhereMail[0].Jmeno = ;
                selectWhereMail[0].Prijmeni = prijmeni.Text;
                selectWhereMail[0].Telefon = int.Parse(telefon.Text);
                selectWhereMail[0].PIN = int.Parse(pin.Text);
                selectWhereMail[0].UliceCP = ulice.Text;
                selectWhereMail[0].Obec = obec.Text;
                selectWhereMail[0].PSC = int.Parse(psc.Text);
                App.DatabazeUzivatelu.SaveItemAsync(selectWhereMail[0]);

                mail = selectWhereMail[0].Email;
            } else
            {*/
            //}

            Uzivatel uzivatel = new Uzivatel();
            uzivatel.Jmeno = jmeno.Text;
            uzivatel.Prijmeni = prijmeni.Text;
            uzivatel.Telefon = Int32.Parse(telefon.Text);
            uzivatel.Email = email.Text;
            uzivatel.PIN = Int32.Parse(pin.Text);
            uzivatel.UliceCP = ulice.Text;
            uzivatel.Obec = obec.Text;
            uzivatel.PSC = Int32.Parse(psc.Text);
            App.DatabazeUzivatelu.SaveItemAsync(uzivatel);


            var userIDsql = App.DatabazeUzivatelu.GetAllIDs().Result.First();
            int Userid = userIDsql.ID;

            var mnozstviSQL = App.CartDatabase.GetNumberOfItemsInCart().Result;
            List<int> pocetKusu = new List<int>();
            foreach (Kosik kosik in mnozstviSQL)
            {
                int mnozstvi = kosik.Mnozstvi;
                pocetKusu.Add(mnozstvi);
            }
            mnozstviZbozi = pocetKusu;

            Objednavka objednavka = new Objednavka();
            objednavka.IDzbozi = zboziObjednavky;
            objednavka.mnozstviZbozi = mnozstviZbozi;
            objednavka.IDuzivatele = Userid;
            App.DatabazeObjednavek.SaveItemAsync(objednavka);



        }
    }
}
