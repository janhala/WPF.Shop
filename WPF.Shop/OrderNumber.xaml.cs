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

namespace WPF.Shop
{
    /// <summary>
    /// Interakční logika pro OrderNumber.xaml
    /// </summary>
    public partial class OrderNumber : Page
    {
        public OrderNumber(int orderNumber)
        {
            InitializeComponent();

            orderNumberLBL.Content = "Číslo vaší objednávky: " + orderNumber + "(automaticky zkopírováno do schránky)";
            Clipboard.SetText(orderNumber.ToString());
        }
    }
}
