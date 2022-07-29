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
using MessageBox = System.Windows.MessageBox;
using System.Data;
using System.Data.SqlClient;
using LMS.BL;
using LMS.DAL;
namespace LMS.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlNotifications.xaml
    /// </summary>
    public partial class UserControlReturnBooks : UserControl
    {
        DbConnection dbcon = new DbConnection();
        ClassBorrower cl = new ClassBorrower();
        MainWindow main = new MainWindow();
        DataTable dt = new DataTable();
        TextBlock txt_borrid = new TextBlock();
        public UserControlReturnBooks()
        {
            InitializeComponent();
            load_grid_laters();




        }

        public void load_grid_laters()
        {
            DataTable Dt = new DataTable();
            Dt = cl.GET_All_laters();
            grid_loan_laters.ItemsSource = Dt.DefaultView;
        }




        



        



       





      

        


        private void grid_loan_laters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid_loan_laters.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)grid_loan_laters.SelectedItems[0];
                TextBlock txt = new TextBlock();

                txt.Text = x[0].ToString();

                DataTable dt = cl.GetDetailesByLoanID(Convert.ToInt32(txt.Text));
                dg_detailes.ItemsSource = dt.DefaultView;
            }
        }

        private void txt_search_for_borrname_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataTable Dt = cl.search_borrowerblackbyname(txt_search_for_borrname.Text);
            grid_loan_laters.ItemsSource = Dt.DefaultView;

        }

        private void search_for_loan_date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable Dt = cl.search_borrowerblackbydate(search_for_loan_date.Text);
            grid_loan_laters.ItemsSource = Dt.DefaultView;
        }
    }
}


