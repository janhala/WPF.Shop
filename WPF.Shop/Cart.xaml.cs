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

namespace WPF.Shop
{
    /// <summary>
    /// Interakční logika pro Cart.xaml
    /// </summary>
    public partial class Cart : Page
    {
        public Cart(List<int> kosik)
        {
            InitializeComponent();

            //int[] mnozstvi = new int[999];

            foreach (int idZbozi in kosik)
            {
                /*if (mnozstvi[idZbozi] == 0)
                {
                    mnozstvi.SetValue(1, idZbozi);
                } else
                {
                    mnozstvi.SetValue(mnozstvi[idZbozi] + 1, idZbozi);
                }*/

                if (App.CartDatabase.GetbyID(idZbozi).Result.Count() > 0) {
                    App.CartDatabase.AktualizovatPocetKusuZbozi(idZbozi);
                } else {
                    var queryofItems = App.DatabazeZbozi.GetItemAsyncByID(idZbozi).Result;

                    Kosik cart = new Kosik();
                    cart.ID = queryofItems.ID;
                    cart.NazevZbozi = queryofItems.NazevZbozi;
                    cart.Cena = queryofItems.Cena;
                    cart.Mnozstvi = 1;
                    App.CartDatabase.SaveItemAsync(cart);
                }                
            }


            var queryCart = App.CartDatabase.GetItemsAsync().Result;
            CartLV.ItemsSource = queryCart;            
        }

        private void CartLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
