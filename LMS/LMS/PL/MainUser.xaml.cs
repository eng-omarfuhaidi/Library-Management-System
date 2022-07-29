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
    public partial class MainUser : Window
    {
        MainWindow main = new MainWindow();
     
        Class_User cl = new Class_User();
        public MainUser()
        {
            InitializeComponent();
            ItemUser.IsEnabled = false;
            
         
            txt_username.Visibility=Visibility.Visible;
            btn_back.Visibility = Visibility.Collapsed;

        }

        

        

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {




           

            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemBooks":
                    MainBook mb = new MainBook();
                    mb.txt_username.Text = this.txt_username.Text;
                    
                    mb.Show();
                    this.Close();
                    break;
                case "ItemBorrowing":
                    MainLoan ml = new MainLoan();
                    ml.txt_username.Text = this.txt_username.Text;
                    ml.Show();
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

        private void br_usermanagement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            GridMain.Visibility = Visibility.Collapsed;
            UserControl uc;
            uc = new UserControlUsers();
            grid1.Children.Add(uc);
            btn_back.Visibility = Visibility.Visible;

        }

        private void btn_back_Click_2(object sender, RoutedEventArgs e)
        {
            grid1.Children.Clear();
            GridMain.Visibility = Visibility.Visible;
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
    }
}
