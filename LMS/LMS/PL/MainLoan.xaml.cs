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
using LMS.UserControls;
using LMS.BL;
namespace LMS
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainLoan : Window
    {
        MainWindow main = new MainWindow();

        Class_User cl = new Class_User();
        public MainLoan()
        {
            
            InitializeComponent();
            ItemBorrowing.IsEnabled = false;
            txt_username.Visibility=Visibility.Visible;
            txt_username.Text = main.txt_username.Text;
            btn_back.Visibility = Visibility.Collapsed;
            

        }

      
       

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            

      


            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemBooks":
                    MainBook mn = new MainBook();
                    mn.txt_username.Text = this.txt_username.Text;
                    mn.Show();
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

        private void add_borrower_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            UserControl uc;
            uc = new UserControlNewBorroer();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }

        private void btn_back_Click_2(object sender, RoutedEventArgs e)
        {
            grid1.Children.Clear();
            GridMain.Visibility = Visibility.Visible;

        }

        private void new_borrowing_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            UserControl uc;
            uc = new UserControlAddBorrowing();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }

        private void br_loanmanagement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            UserControl uc;
            uc = new UserControlLoanManagement();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            main.txt_username.Text = this.txt_username.Text;
            main.fillnotuficationsnumber();
            main.Show();
            this.Close();
        }

        private void maximiz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {

            grid1.Children.Clear();
            GridMain.Visibility = Visibility.Visible;

            btn_back.Visibility = Visibility.Collapsed;


        }
        public void close()
        {
        }

       

        private void br_request_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            GridMain.Visibility = Visibility.Collapsed;
            UserControl uc;
            uc = new UserControlNotifications();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }

        private void br_laters_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Visibility = Visibility.Collapsed;
            UserControl uc;
            uc = new UserControlReturnBooks();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;
        }
    }
}
