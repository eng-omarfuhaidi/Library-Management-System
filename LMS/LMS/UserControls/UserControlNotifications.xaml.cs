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
    public partial class UserControlNotifications : UserControl
    {
        DbConnection dbcon = new DbConnection();
        ClassBorrower cl = new ClassBorrower();
        MainWindow main = new MainWindow();
        DataTable dt = new DataTable();
        TextBlock txt_borrid = new TextBlock();
        public UserControlNotifications()
        {
            InitializeComponent();
            loadrequest();
            fillrequestnumber();
            loadjoining();
            filljoiningnumber();
        }


        private void btn_joinigrequisting_Click(object sender, RoutedEventArgs e)
        {
            this.grid_joining.Visibility = Visibility.Visible;
        }
        public void loadrequest()
        {
            DataTable Dt = new DataTable();
            Dt = cl.GET_Allrequest();
            dg_requests.ItemsSource = Dt.DefaultView;
        }




        public void loadjoining()
        {
            DataTable Dt = new DataTable();
            Dt = cl.GET_Alljoining();
            grid_joining.ItemsSource = Dt.DefaultView;
        }




        public void fillrequestnumber()
        {
            dbcon.conOpen();

            SqlCommand cmd = new SqlCommand(" select COUNT(*)from  reserve_request where accepting_state=@accepting_state ", dbcon.Con);
            cmd.Parameters.AddWithValue("@accepting_state", false);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            if (Ra.HasRows)
            {

                txt_requestnumber.Text = Ra[0].ToString();

            }
            dbcon.conclose();
            Ra.Close();

        }



        public void filljoiningnumber()
        {
            dbcon.conOpen();

            SqlCommand cmd = new SqlCommand(" select COUNT(*)from  tbjoin_request where accept_state=@accepting_state ", dbcon.Con);
            cmd.Parameters.AddWithValue("@accepting_state", false);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            if (Ra.HasRows)
            {

                txt_joiningnumber.Text = Ra[0].ToString();

            }
            dbcon.conclose();
            Ra.Close();

        }





        private void btn_request_Click(object sender, RoutedEventArgs e)
        {
            dg_requests.Visibility = Visibility.Visible;
            grid_joining.Visibility = Visibility.Collapsed;
            btn_acceptjoining.IsEnabled = false;
            btn_acceptrequesr.IsEnabled = false;
        }

        private void btn_joining_Click(object sender, RoutedEventArgs e)
        {
            grid_joining.Visibility = Visibility.Visible;
            dg_requests.Visibility = Visibility.Collapsed;
            btn_acceptjoining.IsEnabled = false;
            btn_acceptrequesr.IsEnabled = false;
        }

        private void grid_joining_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_acceptjoining.IsEnabled = true;


        }

        private void dg_requests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_acceptrequesr.IsEnabled = true;
        }



        private void btn_acceptrequesr_Click_1(object sender, RoutedEventArgs e)
        {
            if (dg_requests.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_requests.SelectedItems[0];
                 TextBlock txt1 = new TextBlock();
                TextBlock txt2 = new TextBlock();
                TextBlock txt3 = new TextBlock();
                txt1.Text = x[3].ToString();

                cl.UPDATE_reservingstate(Convert.ToInt32(x[3].ToString()), Convert.ToInt32(x[0].ToString()));


                dbcon.conOpen();
                if (dbcon.Con != null)
                {

                    SqlCommand cmdn = new SqlCommand("select book_id from tblcopy WHERE copy_id=@copy_id", dbcon.Con);
                    cmdn.Parameters.AddWithValue("@copy_id", txt1.Text);
                    SqlDataReader Ra = cmdn.ExecuteReader();
                    Ra.Read();

                    txt2.Text = Ra[0].ToString();
                    Ra.Close();

                }

                  
                dbcon.conOpen();
                if (dbcon.Con != null)
                {

                    SqlCommand cmdn = new SqlCommand("select avaliablecopies_num from tblbook WHERE book_id=@book_id", dbcon.Con);
                    cmdn.Parameters.AddWithValue("@book_id", txt2.Text);
                    SqlDataReader Ra = cmdn.ExecuteReader();
                    Ra.Read();

                    txt3.Text = Ra[0].ToString();
                    Ra.Close();

                }


                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "UPDATE tblbook SET avaliablecopies_num= @avaliablecopies_num  WHERE book_id = @book_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                    cmd.Parameters.AddWithValue("@avaliablecopies_num", Convert.ToInt32(txt3.Text) - 1);
                    cmd.Parameters.AddWithValue("@book_id", txt2.Text);
                    cmd.ExecuteNonQuery();
                }
                dbcon.conclose();




            }
            loadrequest();
            fillrequestnumber();
         
            MessageBox.Show("تم الحجز بنجاح");
        }

        private void btn_acceptjoining_Click(object sender, RoutedEventArgs e)
        {
            try { 
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (borrow_id)+1,1) from tblborrower", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_borrid.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
             
            if (grid_joining.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)grid_joining.SelectedItems[0];
                DataTable dt = cl.Getjoiningrequestdata(Convert.ToInt32(x[0].ToString()));
                
                    foreach (DataRow dr in dt.Rows)
                {



                    cl.acceptJoininrequest(Convert.ToInt32(txt_borrid.Text), dr["full_name"].ToString()
                        , dr["email"].ToString(), dr["log_in_name"].ToString(), dr["password"].ToString(), Convert.ToInt32(dr["user_type"].ToString()), dr["notes"].ToString(),
                        Convert.ToInt32(dr["alsmahiaa"].ToString()));
                       MessageBox.Show("تم الانضمام بنجاح");

                    }
                    cl.UPDATE_joiningrequeststate(Convert.ToInt32(x[0].ToString()));

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loadjoining();
            filljoiningnumber();

        }



    }
}


