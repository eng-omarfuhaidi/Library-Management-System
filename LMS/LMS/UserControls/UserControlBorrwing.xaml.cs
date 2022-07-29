using LMS.UserControls;
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

namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControlBorrwing.xaml
    /// </summary>
    public partial class UserControlBorrwing : UserControl
    {
        UserControl uc;
        MainWindow ma = new MainWindow();
        public UserControlBorrwing()
        {
            InitializeComponent();
          
        }

        private void br_addcatogray_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {//if(ma.GridMain.IsInitialized==true)

            //  ma.GridMain.Children.Remove(this);
            uc = new UserControlBookOPeration();

        }


        private void add_borrower_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            UserControl uc;
            uc = new UserControlNewBorroer();
            ma.GridMain.Children.Add(uc);
            ma.Show();
        }

        private void new_borrowing_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //  Borrowers_list br = new Borrowers_list();
            UserControl uc;
            uc= new UserControlAddBorrowing();
            ma.GridMain.Children.Add(uc);
            ma.Show();

        }

        private void br_loanmanagement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserControl uc;
            uc = new UserControlLoanManagement();
            ma.GridMain.Children.Add(uc);
            ma.Show();

        }

        private void br_requests_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserControl uc;
            uc = new UserControlNotifications();
            ma.GridMain.Children.Add(uc);
            ma.Show();
        }
    }
}
