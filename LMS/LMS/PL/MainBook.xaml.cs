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
using LMS.BL;
namespace LMS
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainBook : Window
    {
       // StartupUri="UserControls/login.xaml"
        MainWindow main = new MainWindow();
        Class_User cl = new Class_User();
        Login lg = new Login();
        public MainBook()
        {
            InitializeComponent();
            ItemBooks.IsEnabled = false;
            //   ButtonCloseMenu.Visibility = Visibility.Collapsed;
            //  ButtonOpenMenu.Visibility = Visibility.Visible;
            //  ListViewMenu.Visibility = Visibility.Collapsed;
            btn_back.Visibility = Visibility.Collapsed;
            txt_username.Visibility=Visibility.Visible;
            txt_username.Text = main.txt_username.Text;
          

        }

       

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            

           


            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                

                case "ItemBorrowing":
                    MainLoan ml = new MainLoan();
                    ml.txt_username.Text = this.txt_username.Text;
                    ml.Show();
                    this.Close();
                    break;
                case "ItemUser":
                    MainUser mu = new MainUser();
                    mu.txt_username.Text = this.txt_username.Text;
                    mu.Show();
                    this.Close();
                    break;
                /*case "Item_report":
                    usc = new UserControlPrivlages();
                    GridMain.Children.Add(usc);
                    break;

                case "Item_backup":
                    usc = new UserControlAddLanguage();
                    GridMain.Children.Add(usc);
                    break;*/

                default:
                    break;
            }
        }

        private void book_management_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility=Visibility.Collapsed;
            UserControl uc;
            uc = new UserControlBookManagement();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;

        }

        private void br_addbooks_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            UserControl uc;
            uc = new UserControlAddBook();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;

        }

        private void br_addcopy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            GridMain.Visibility = Visibility.Collapsed;
            UserControl uc;
            uc = new UserControlAddCopy();
            grid1.Children.Add(uc);
           btn_back.Visibility = Visibility.Visible;
        }

     

       
        
        private void btn_back_Click_2(object sender, RoutedEventArgs e)
        {
            grid1.Children.Clear();
           GridMain.Visibility = Visibility.Collapsed;
            grid2.Visibility=Visibility.Visible;
            btn_back.Visibility = Visibility.Collapsed;
           
            
     
        }

        private void maximiz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            main.txt_username.Text = this.txt_username.Text;
            main.Show();
            this.Close();
        }

        private void br_bookoperation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grid2.Visibility = Visibility.Collapsed;
            grid1.Children.Clear();
            GridMain.Visibility = Visibility.Visible;
            btn_back.Visibility = Visibility.Visible;

        }

        private void br_addauthor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
            grid1.Children.Clear();
            UserControl uc;
            uc = new UserControlAddAuothor();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }

        private void br_addcatogray_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
            grid1.Children.Clear();
            UserControl uc;
            uc = new UserControlAddCatogray();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }

        private void br_addpublisher_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
            grid1.Children.Clear();
            UserControl uc;
            uc = new UserControlAddPublisher();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }

        private void br_addexaminer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
            grid1.Children.Clear();
            UserControl uc;
            uc = new UserControlAddExaminer();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }

        private void br_translator_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
            grid1.Children.Clear();
            UserControl uc;
            uc = new UserControlAddTranslator();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }

        private void br_addtypes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
            grid1.Children.Clear();
            UserControl uc;
            uc = new UserControlAddType();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }

        private void br_addlanguage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Collapsed;
            grid1.Children.Clear();
            UserControl uc;
            uc = new UserControlAddLanguage();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }
    }
    }

