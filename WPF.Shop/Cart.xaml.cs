using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        public Cart(List<int> KosikList)
        {
            InitializeComponent();

            int soucetCen = 0;
            List<int> zboziObjednavkyList = new List<int>();
            List<int> mnozstviZboziList = new List<int>();

            if (KosikList.Count > 0)
            {
                // pouziti LINQ
                var q = from x in KosikList
                        group x by x into g
                        let count = g.Count()
                        orderby count descending
                        select new { idZbozi = g.Key, Count = count };
                foreach (var x in q)
                {
                    Zbozi queryFromCart = App.DatabazeZbozi.GetItemByIDRest(x.idZbozi);
                    
                    Kosik cart = new Kosik();
                    cart.IDzbozi = x.idZbozi;
                    cart.NazevZbozi = queryFromCart.NazevZbozi;
                    cart.Cena = queryFromCart.Cena;
                    cart.Mnozstvi = x.Count;
                    if (soucetCen == 0)
                    {
                        soucetCen = cart.Cena;
                    }
                    else
                    {
                        soucetCen = cart.Cena + soucetCen;
                    }
                    App.CartDatabase.SaveItemAsync(cart);
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


            this.Loaded += new RoutedEventHandler(LoadLV);
        }

        private void CartLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OdstranitZeSeznamu(object sender, RoutedEventArgs e)
        {
            int zboziKeSmazani = (int)(e.Source as Button).Tag;
            App.CartDatabase.OdstranitZbozi(zboziKeSmazani);

            var queryCart = App.CartDatabase.GetItemsAsync().Result;
            CartLV.ItemsSource = queryCart;
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
            int telefonNum = 0;
            Int32.TryParse(telefon.Text, out telefonNum);
            int pinNum = 0;
            Int32.TryParse(pin.Text, out pinNum);
            int pscNum = 0;
            Int32.TryParse(psc.Text, out pscNum);

            if (jmeno.Text != null && jmeno.Text != "" && prijmeni.Text != null && prijmeni.Text != "" && telefon.Text != null && telefon.Text != "" && email.Text != null && email.Text != "" &&
                pin.Text != null && pin.Text != "" && ulice.Text != null && ulice.Text != "" && obec.Text != null && obec.Text != "" && psc.Text != null && psc.Text != "" &&
                pscNum != 0 && telefonNum != 0 && pscNum != 0)
            {
                Uzivatel uzivatel = new Uzivatel();
                uzivatel.Jmeno = jmeno.Text;
                uzivatel.Prijmeni = prijmeni.Text;
                uzivatel.Telefon = telefonNum;
                uzivatel.Email = email.Text;
                uzivatel.PIN = pinNum;
                uzivatel.UliceCP = ulice.Text;
                uzivatel.Obec = obec.Text;
                uzivatel.PSC = pscNum;
                App.DatabazeUzivatelu.SaveItemRest(uzivatel);

                List<Uzivatel> userIDsql = App.DatabazeUzivatelu.GetAllIDsRest();
                int Userid;
                if (userIDsql == null)
                {
                    Userid = 1;
                } else
                {
                    Userid = userIDsql[0].ID;
                }

                var mnozstviSQL = App.CartDatabase.GetNumberOfItemsInCart().Result;
                List<int> pocetKusu = new List<int>();
                foreach (Kosik kosik in mnozstviSQL)
                {
                    int mnozstvi = kosik.Mnozstvi;
                    pocetKusu.Add(mnozstvi);
                }
                mnozstviZbozi = pocetKusu;

                Int32 randomNumber = 0;
                Random rnd = new Random();
                randomNumber = rnd.Next(1000, 99999);
                Objednavka objednavka = new Objednavka();
                objednavka.IDuzivatele = Userid;
                objednavka.typDopravy = doprava;
                objednavka.cisloObjednavky = randomNumber;
                App.DatabazeObjednavek.SaveItemRest(objednavka);
                var lastInsertedOrder = App.DatabazeObjednavek.GetWhereOrderNumberRest(randomNumber);
                int orderID = lastInsertedOrder[0].ID;


                foreach (Kosik zm in CartLV.ItemsSource)
                {
                    Objednavka_Zbozi objednavka_Zbozi = new Objednavka_Zbozi();
                    objednavka_Zbozi.IDobjednavky = orderID;
                    objednavka_Zbozi.IDzbozi = zm.IDzbozi;
                    objednavka_Zbozi.mnozstviZbozi = zm.Mnozstvi;
                    App.DatabazeObjednavkaZbozi.SaveItemRest(objednavka_Zbozi);
                }

                App.CartDatabase.OdstranitVsechnoZbozi();

                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.Navigate(new OrderNumber(randomNumber));
            } else
            {
                MessageBox.Show("Vyplňte všechny údaje, nebo zkontrolujte správnost zadaných.");
            }
        }

        private void VyprazdnitKosik(object sender, RoutedEventArgs e)
        {
            App.CartDatabase.OdstranitVsechnoZbozi();

            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new StartPage());
        }

        void LoadLV(object sender, RoutedEventArgs e)
        {
            var queryCart = App.CartDatabase.GetItemsAsync().Result;
            CartLV.ItemsSource = queryCart;
        }
    }

}
