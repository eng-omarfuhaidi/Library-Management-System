using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;
using LMS.BL;
using LMS.DAL;
namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControlLoanManagement.xaml
    /// </summary>
    public partial class UserControlLoanManagement : UserControl
    {
        ClassBorrower cb = new ClassBorrower();
        DbConnection dbcon = new DbConnection();
        TextBlock text1 = new TextBlock();
        TextBlock text2 = new TextBlock();
        TextBlock text3 = new TextBlock();

        public UserControlLoanManagement()
        {
            InitializeComponent();
            dg_loanlist.ItemsSource = cb.GET_AllLoans().DefaultView;
            date_borrowingdate.SelectedDate = DateTime.Today;
            txt_qty.IsEnabled = false;
        }

        private void dg_loanlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_loanlist.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_loanlist.SelectedItems[0];
                TextBlock txt = new TextBlock();

                txt.Text = x[0].ToString();

                DataTable dt = cb.GetDetailesByLoanID(Convert.ToInt32(txt.Text));
                dg_detailes.ItemsSource = dt.DefaultView;
                txt_borrowingnumber.Text = x[0].ToString();
                txt_BorrDisc.Text = x[1].ToString();
                date_borrowingdate.Text = x[2].ToString();
                txt_period.Text = x[3].ToString();
                date_return.Text = x[4].ToString();
                txt_LibClerck.Text = x[5].ToString();
                txt_borrower_name.Text = x[6].ToString();
                txt_qty.Text = x[7].ToString();
                txt_qty.IsEnabled = true;   



            }




        }

        private void txt_period_KeyUp(object sender, KeyEventArgs e)
        {
           
          
            try
            {
                if (txt_qty.Text != null)
                {


                    date_return.SelectedDate = DateTime.Today.AddDays(Convert.ToDouble(txt_period.Text));
                }
               
                
            }

            catch(Exception exe)
            {
                System.Windows.MessageBox.Show(exe.Message);
            }

        }

        private void txt_search_borr_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataTable Dt = cb.search_borr_by_name(txt_search_borr_name.Text);
            dg_loanlist.ItemsSource = Dt.DefaultView;
          
        }

      

       

      
        

       

        private void date_searching_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataTable Dt = cb.search_borr_by_date(date_searching.Text);
            dg_loanlist.ItemsSource = Dt.DefaultView;
        }

        
        private void txt_period_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txt_qty.Text != null)
                {


                    date_return.SelectedDate = DateTime.Today.AddDays(Convert.ToDouble(txt_period.Text));
                }
                else if(txt_qty.Text == null)
                {
                    date_return.SelectedDate = DateTime.Today.AddDays(0);
                }

            }

            catch (Exception exe)
            {
                System.Windows.MessageBox.Show(exe.Message);
            }
        }

        private void btn_return_loan_Click(object sender, RoutedEventArgs e)
        {

            if (dg_loanlist.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_loanlist.SelectedItems[0];
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "UPDATE tblloan SET return_status = @status ,IsInBlackMenue=@IsInBlackMenue WHERE loan_id =@loan_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
           
                    cmd.Parameters.AddWithValue("@status", true);
                    cmd.Parameters.AddWithValue("@status", false);
                    cmd.Parameters.AddWithValue("@loan_id",x[0].ToString());
                    cmd.ExecuteNonQuery();


                    string query1 = "select copy_id from  tblloandetails where loan_id = @loan_id  ";
                    SqlCommand cmd1 = new SqlCommand(query1, dbcon.Con);
                    cmd1.Parameters.AddWithValue("@loan_id", x[0].ToString());
                    SqlDataReader R1 = cmd1.ExecuteReader();
                   
                    R1.Read();
                    text1.Text = R1[0].ToString();
                    R1.Close();



                    string query2 = "UPDATE tblcopy SET status  = @status  WHERE copy_id =@copy_id";
                    SqlCommand cmd2 = new SqlCommand(query2, dbcon.Con);
                    cmd2.Parameters.AddWithValue("@status", false);
                    cmd2.Parameters.AddWithValue("@copy_id", text1.Text);
                    cmd2.ExecuteNonQuery();




                    SqlCommand cmd3 = new SqlCommand("select book_id from tblloandetails WHERE copy_id=@copy_id", dbcon.Con);
                    cmd3.Parameters.AddWithValue("@copy_id", text1.Text);
                    SqlDataReader R2 = cmd3.ExecuteReader();
                    R2.Read();
                    text2.Text = R2[0].ToString();
                    R2.Close();






                    SqlCommand cmd4 = new SqlCommand("select avaliablecopies_num from tblbook WHERE book_id=@book_id", dbcon.Con);
                    cmd4.Parameters.AddWithValue("@book_id", text2.Text);
                    SqlDataReader R3 = cmd4.ExecuteReader();
                    R3.Read();

                    text3.Text = R3[0].ToString();
                    R3.Close();





                    string query3 = "UPDATE tblbook SET avaliablecopies_num= @avaliablecopies_num  WHERE book_id = @book_id";
                    SqlCommand cmd5 = new SqlCommand(query3, dbcon.Con);
                    cmd5.Parameters.AddWithValue("@avaliablecopies_num", Convert.ToInt32(text3.Text) + 1);
                    cmd5.Parameters.AddWithValue("@book_id", text2.Text);
                    cmd5.ExecuteNonQuery();
                }

                dbcon.conclose();
                dg_loanlist.ItemsSource = cb.GET_AllLoans().DefaultView;
                dg_detailes.ItemsSource = null;
                MessageBox.Show("تم إعادة الإعارة بنجاح");

            }
        }
    }
}
