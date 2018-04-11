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
                    var queryFromCart = App.DatabazeZbozi.GetItemAsyncByID(x.idZbozi).Result;
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


            var userIDsql = App.DatabazeUzivatelu.GetAllIDs().Result;
            int Userid = userIDsql[0].ID;

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
            foreach (Kosik zm in CartLV.ItemsSource)
            {
                Objednavka objednavka = new Objednavka();
                objednavka.IDzbozi = zm.IDzbozi;
                objednavka.mnozstviZbozi = zm.Mnozstvi;
                objednavka.IDuzivatele = Userid;
                objednavka.typDopravy = doprava;
                objednavka.cisloObjednavky = randomNumber;
                App.DatabazeObjednavek.SaveItemAsync(objednavka);
            }

            App.CartDatabase.OdstranitVsechnoZbozi();

            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new OrderNumber(randomNumber));
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
