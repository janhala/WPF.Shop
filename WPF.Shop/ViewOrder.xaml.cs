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
    /// Interakční logika pro ViewOrder.xaml
    /// </summary>
    public partial class ViewOrder : Page
    {
        public ViewOrder()
        {
            InitializeComponent();
        }

        private void VypsatObjednavku(object sender, RoutedEventArgs e)
        {
            int orderNumber = 0;
            Int32.TryParse(cisloObjednavky.Text, out orderNumber);

            if (orderNumber != 0)
            {
                List<Objednavka> getOrderItems = App.DatabazeObjednavek.GetWhereOrderNumberRest(orderNumber);

                if (getOrderItems != null)
                {
                    if (getOrderItems.Count < 1)
                    {
                        pinLBL.Visibility = Visibility.Visible;
                        pinLBL.Content = "Objednávka s tímto číslem neexistuje!!";
                    }
                    else
                    {
                        pinLBL.Visibility = Visibility.Collapsed;
                        objednavkaLV.ItemsSource = getOrderItems;
                    }
                }
            } else
            {
                MessageBox.Show("Zadejte číslo Vaší objednávky.", "Upozornění");
            }
                     
        }

        private void ZobrazitPIN(object sender, RoutedEventArgs e)
        {
            stornoBTN.Visibility = Visibility.Collapsed;
            pinLBL.Visibility = Visibility.Visible;
            pin.Visibility = Visibility.Visible;
            pinBTN.Visibility = Visibility.Visible;
        }

        private void StornovatObjednavku(object sender, RoutedEventArgs e)
        {
            int pinNumber = 0;
            Int32.TryParse(pin.Text, out pinNumber);

            int cisloObjednavkyNum;
            Int32.TryParse(cisloObjednavky.Text, out cisloObjednavkyNum);

            if (cisloObjednavky.Text != null && cisloObjednavky.Text != "" && pinNumber != 0 && cisloObjednavkyNum != 0)
            {
                List<Uzivatel> sqlPIN = App.DatabazeUzivatelu.CheckPINRest(cisloObjednavkyNum);
                 
                if (sqlPIN[0].PIN == pinNumber)
                {
                    App.DatabazeObjednavek.StornovatObjednavkuRest(cisloObjednavkyNum);

                    pinLBL.Visibility = Visibility.Visible;
                    pinLBL.Content = "Úspěšně stornováno, těšíme se na další nákup :)";
                    pin.Visibility = Visibility.Collapsed;
                    pinBTN.Visibility = Visibility.Collapsed;
                }
                else
                {
                    pinLBL.Visibility = Visibility.Visible;
                    pinLBL.Content = "Zadejte PIN znovu, zadaný PIN nesouhlasí: ";
                }
            } else
            {
                pinLBL.Visibility = Visibility.Visible;
                pinLBL.Content = "Objednávka s tímto číslem neexistuje, nebo jste chybně zadali Váš PIN.";
            }            
        }
    }
}
