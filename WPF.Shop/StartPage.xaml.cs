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
using System.Diagnostics;
using RestSharp;
using RestSharp.Deserializers;

namespace WPF.Shop.Pages
{
    /// <summary>
    /// Interakční logika pro StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        string[] CategoryArr;
        List<int> KosikList = new List<int>();
        int celkovaCenaZbozi;
        int pocetKusuZbozi;
        int cartClickAllowed;
        public StartPage()
        {
            InitializeComponent();

            PridatKategorieZbozi();
            PridatProdukty();

            /*
             * ziskani kategorii
             */
            List<Kategorie> queryofcategories;
            if (App.CheckForInternetConnection() == false)
            {
                queryofcategories = App.DatabazeKategorii.GetItemsNotDoneAsync().Result;
            } else
            {
                queryofcategories = App.DatabazeKategorii.GetItemsRest();
            }
            KategorieLV.ItemsSource = queryofcategories;

            /*
             * ziskani zbozi
             */
            List<Zbozi> queryofproducts;
            if (App.CheckForInternetConnection() == false)
            {
                queryofproducts = App.DatabazeZbozi.GetItemsNotDoneAsync().Result;
            }
            else
            {
                queryofproducts = App.DatabazeZbozi.GetItemsRest();
            }
            ZboziLV.ItemsSource = queryofproducts;

            /*
             * ziskani polozek v kosiku
             */
            var queryofcart = App.CartDatabase.GetItemsAsync().Result;
            if (queryofcart.Count > 0)
            {
                int soucetCen = 0;
                int soucetPoctuKusu = 0;
                foreach (Kosik kosik in queryofcart)
                {
                    if (soucetCen == 0)
                    {
                        soucetCen = kosik.Cena;
                    } else
                    {
                        soucetCen = kosik.Cena + soucetCen;
                    }

                    soucetPoctuKusu = kosik.Mnozstvi;
            }

                kosikCena.Text = soucetCen + " Kč";
                kosikPocetKusu.Text = soucetPoctuKusu.ToString() + " ks";

                prazdnyKosik.Visibility = Visibility.Collapsed;
                kosikCena.Visibility = Visibility.Visible;
                kosikPocetKusu.Visibility = Visibility.Visible;

                cartClickAllowed = 1;
            }
            
        }

        private void KategorieLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = KategorieLV.SelectedItem as Kategorie;
            int kategorieZbozi = item.ID;

            List<Zbozi> queryofproducts;
            if (KategorieLV.SelectedItem != null)
            {
                if (App.CheckForInternetConnection() == false)
                {
                    queryofproducts = App.DatabazeZbozi.GetWhereCategoryIs(kategorieZbozi).Result;
                }
                else
                {
                    queryofproducts = App.DatabazeZbozi.GetWhereCategoryIsRest(kategorieZbozi);
                }

                ZboziLV.ItemsSource = queryofproducts;
            }

            
        }

        public void PridatProdukty()
        {
            string[] NazvyZbozi = new string[] { "Samsung Galaxy J5 (2016) LTE, černá", "Apple iPhone SE 32GB, šedá", "Honor 8, modrá", "Lenovo IdeaCentre AiO 510-23" };
            int[] CenyZbozi = new int[] { 4990, 12990, 9990, 19999 };
            int[] CenyPredSlevou = new int[] { 6313, 0, 11028, 0 };
            int[] KategorieZbozi = new int[] { 1, 1, 1, 2 }; // "Mobilní telefony" == 1, "Počítače" == 2, "Televize" == 3
            string[] PopisyZbozi = new string[] { "Chytrý telefon Samsung Galaxy J5 (2016) Dual SIM proti svému předchůdci přichází s řadou vylepšení. Narostla nám úhlopříčka Super AMOLED displeje, kapacita operační a interní paměti, kapacita baterie, vylepšeny jsou fotoaparáty a to vše je zabaleno, místo plastu, v krásném kovovém designu. Galaxy J5 (2016) představuje kombinaci solidní konstrukce, pěkného výkonu a skvělých funkcí pro fotografie, videa a oblíbená selfie.", "Nejnovější chytrý telefon Apple iPhone SE se vrací ke kořenům klasického kompaktního designu 4“ telefonu jak ho znáte z dob iPhone 5s. Ovšem uvnitř najdete ty nejnovější technologie, které znáte z iPhone 6s. Opět si můžete užívat krásu Retina displeje, oblíbené kamery iSight a FaceTime HD, rychlé připojení a samozřejmě skvělý intuitivní operační systém iOS ve verzi 9. V krásném a kompaktním designu tak získáte telefon nabitý výkonem z dílen Apple.", "Naváže Honor 8 na úspěch modelů 6 a 7? Těžko o tom pochybovat, svou výbavou a zajímavou cenou má našlápnuto k úspěchu. Stejně jako předchůdci je bratrem top modelu ze stáje Huawei, v tomto případě P9. Vstupte do světa mobilní fotografie na nové úrovni. Zadní fotoaparát s dvojicí snímačů je stejně jako u P9 opravdovou špičkou. A na špičku patří telefon Honor 8 také svým výkonem. Nadčasová elegance, velká 5.2'' obrazovka s úchvatnými barvami, rychlost 4G, systém Android 6.0 a štíhlý design smartphone doslova berou dech. Vysoký výkon smartphonu dodává extrémně rychlý 8jádrový procesor za přispění 4 GB paměti RAM. Získejte eleganci a výkon za příjemnou cenu v podobě Honor 8.", "Bavte se a pracujte s tenkým a elegantním all-in-one počítačem Lenovo IdeaCentre AiO 510. Je charakteristický krásným, bezrámovým displejem, zvládne i náročné požadavky a s přehledem splní vaše očekávání v oblasti zábavy. IdeaCentre AiO 510 se stane nejen výkonným společníkem, ale také ozdobou interiéru." };
            int[] PocetKusuSkladem = new int[] { 3, 66, 888, 10 };
            int[] VyprodejZbozi = new int[] { 1, 1, 1, 0 };
            string[] FotkyZbozi = new string[] { "Assets/samsung.jpg", "Assets/iphone.jpg", "Assets/honor.jpg", "Assets/LenovoPC.jpg" };

            for (int i = 0; i < NazvyZbozi.Length; i++)
            {
                Zbozi zbozi = new Zbozi();
                zbozi.NazevZbozi = NazvyZbozi[i];
                zbozi.Cena = CenyZbozi[i];
                zbozi.CenaPredSlevou = CenyPredSlevou[i];
                zbozi.KategorieZbozi = KategorieZbozi[i];
                zbozi.Popis = PopisyZbozi[i];
                zbozi.PocetKusuSkladem = PocetKusuSkladem[i];
                zbozi.Vyprodej = VyprodejZbozi[i];
                zbozi.FotoZbozi = FotkyZbozi[i];

                int count = 0;
                foreach (Zbozi item in App.DatabazeZbozi.GetItemsAsync().Result)
                {
                    if (item.NazevZbozi.Equals(NazvyZbozi[i]))
                    {
                        count += 1;
                    }
                }
                if (count == 0)
                {
                    App.DatabazeZbozi.SaveItemAsync(zbozi);
                }
            }
        }

        public void PridatKategorieZbozi()
        {
            CategoryArr = new string[] { "Mobilní telefony", "Počítače", "Televize" };

            for (int i = 0; i < CategoryArr.Length; i++)
            {
                Kategorie category = new Kategorie();
                category.NazevKategorie = CategoryArr[i];
                int count = 0;
                foreach (Kategorie item in App.DatabazeKategorii.GetItemsAsync().Result)
                {
                    if (item.NazevKategorie.Equals(CategoryArr[i]))
                    {
                        count += 1;
                    }
                }
                if (count == 0)
                {
                    App.DatabazeKategorii.SaveItemAsync(category);
                }
            }
        }

        

        private void ZboziLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PridatDoKosiku(object sender, RoutedEventArgs e)
        {
            if (ZboziLV.SelectedItem != null)
            {
                if (KosikList.Count == 0)
                {
                    prazdnyKosik.Visibility = Visibility.Collapsed;
                    kosikCena.Visibility = Visibility.Visible;
                    kosikPocetKusu.Visibility = Visibility.Visible;
                }

                var item = ZboziLV.SelectedItem as Zbozi;
                int idZbozi = item.ID;

                KosikList.Add(idZbozi);                

                if (celkovaCenaZbozi == 0)
                {
                    celkovaCenaZbozi = item.Cena;
                } else
                {
                    celkovaCenaZbozi = celkovaCenaZbozi + item.Cena;
                }

                kosikCena.Text = celkovaCenaZbozi.ToString() + " Kč";
                

                if (pocetKusuZbozi == 0)
                {
                    pocetKusuZbozi = 1;
                }
                else
                {
                    pocetKusuZbozi = pocetKusuZbozi + 1;
                }

                kosikPocetKusu.Text = pocetKusuZbozi.ToString() + " ks";
            }
        }

        private void ZobrazitKosik(object sender, RoutedEventArgs e)
        {
            if (KosikList.Count > 0 || cartClickAllowed == 1)
            {
                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.Navigate(new Cart(KosikList));
            }
            
        }

        private void ZobrazitObjednavku(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new ViewOrder());
        }
    }
}
