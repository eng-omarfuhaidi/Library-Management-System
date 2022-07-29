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
using System.Data;
using System.Data.SqlClient;
using LMS.BL;
using LMS.DAL;
using LMS.UserControls;

namespace LMS
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        DbConnection dbcon = new DbConnection();
        ClassBorrower b = new ClassBorrower();
        DatePicker dt = new DatePicker();
        DatePicker dateretu = new DatePicker();
        Class_User cl = new Class_User();
        TextBlock txt_temp1 = new TextBlock();
        TextBlock txt_temp2 = new TextBlock();
      
        TextBlock txt1 = new TextBlock();

        public MainWindow()
        {
            InitializeComponent();
            btn_backmenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ListViewMenu.Visibility = Visibility.Collapsed;
            dateretu.SelectedDate = DateTime.Today;
            dt.SelectedDate = DateTime.Today;
            canceling_date.SelectedDate = DateTime.Today.AddDays(Convert.ToDouble(-1));
            DateOfBlackMenue.SelectedDate = DateTime.Today.AddDays(Convert.ToDouble(-5));
            dateofbackup.Text = dt.Text;
            txt_username.Visibility = Visibility.Visible;
            dateofday.SelectedDate = DateTime.Today;
           look_for_laters();
           Cancel_copy_reserved();
          b.update_reserving_state(canceling_date.Text);
           //update avaliablecopies_number
          
          
          ////delete requests
            b.cancel_request(canceling_date.Text);
          
           filltextcopyborrowed();
           filltextloanlater();
           fillnotuficationsnumber();
          filltextborrowernumber();
            txt_loannumber.FontSize = 30;
            txt_borrowernumber.FontSize = 30;
            txt_loannumber.Width = 48;
            txt_borrowernumber.Width = 48;
            look_for_blackloans();
            dg_loanlater.ItemsSource = b.GET_AllLoans_inblack().DefaultView;


        }


        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;

            ListViewMenu.Visibility = Visibility.Visible;


        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ListViewMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            UserControlAddBorrowing uc = new UserControlAddBorrowing();

            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemBooks":
                    MainBook mb = new MainBook();
                    mb.txt_username.Text = this.txt_username.Text;
                    // uc.txt_LibClerck.Text = this.txt_username.Text;
                    mb.Show();
                    this.Close();
                    break;
                case "ItemBorrowing":
                    MainLoan ml = new MainLoan();
                    ml.txt_username.Text = this.txt_username.Text;
                    //   uc.txt_LibClerck.Text = this.txt_username.Text;
                    ml.Show();
                    this.Close();
                    break;
                case "ItemUser":
                    MainUser mu = new MainUser();
                    mu.txt_username.Text = this.txt_username.Text;
                    // uc.txt_LibClerck.Text = this.txt_username.Text;
                    mu.Show();
                    this.Close();
                    break;
                case "Item_report":
                    UserControl ucc;
                    ucc = new UserControlreport();
                    GridMain.Children.Add(ucc);
                    break;

               /* case "Item_backup":
                    usc = new UserControlAddLanguage();
                    GridMain.Children.Add(usc);
                    break;*/

                default:
                    break;
            }
        }

        public void filltextloanlater()
        {
            dbcon.conOpen();

            SqlCommand cmd = new SqlCommand(" select COUNT(*)from  tblloan  where later_status=@status or IsInBlackMenue=@status1  ", dbcon.Con);
            cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar)).Value = true;
            cmd.Parameters.Add(new SqlParameter("@status1", SqlDbType.VarChar)).Value = true;

            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            if (Ra.HasRows)
            {

                txt_loanlater.Text = Ra[0].ToString();

            }
            dbcon.conclose();
            Ra.Close();

        }



        public void fillnotuficationsnumber()
        {
            dbcon.conOpen();

            SqlCommand cmd = new SqlCommand(" select COUNT(*)from  reserve_request where accepting_state=@accepting_state ", dbcon.Con);
            cmd.Parameters.AddWithValue("@accepting_state", false);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            if (Ra.HasRows)
            {

                txt_temp1.Text = Ra[0].ToString();

            }
            dbcon.conclose();
            Ra.Close();



            dbcon.conOpen();

            SqlCommand ccc = new SqlCommand(" select COUNT(*)from  tbjoin_request where accept_state=@accepting_state ", dbcon.Con);
            ccc.Parameters.AddWithValue("@accepting_state", false);
            SqlDataReader ree = ccc.ExecuteReader();
            ree.Read();
            if (ree.HasRows)
            {

                txt_temp2.Text = ree[0].ToString();

            }
            dbcon.conclose();
            ree.Close();


            int m = Convert.ToInt32(txt_temp1.Text) + Convert.ToInt32(txt_temp2.Text);
            txt_notifnumber.Text = m.ToString();
        }



        public void filltextcopyborrowed()
        {
            dbcon.conOpen();

            SqlCommand cmd = new SqlCommand(" select COUNT(*)from  tblcopy where status=@status  ", dbcon.Con);

            cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar)).Value = true;

            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            if (Ra.HasRows)
            {

                txt_loannumber.Text = Ra[0].ToString();

            }
            dbcon.conclose();
            Ra.Close();

        }



        public void filltextborrowernumber()
        {
            dbcon.conOpen();

            SqlCommand cmd = new SqlCommand(" select COUNT(*) from  tblborrower ", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_borrowernumber.Text = Ra[0].ToString();


            dbcon.conclose();
            Ra.Close();

        }



    



        

            public void look_for_laters()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string query = "UPDATE tblloan SET later_status = @status  WHERE return_date Like'%'+@return_date+'%'";
                SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                // bool state = false;
                cmd.Parameters.AddWithValue("@status", true);
                cmd.Parameters.AddWithValue("@return_date", dateofday.Text);
                cmd.ExecuteNonQuery();
            }
            dbcon.conclose();

            filltextloanlater();
            }


        public void look_for_blackloans()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string query = "UPDATE tblloan SET IsInBlackMenue  = @IsInBlackMenue  WHERE return_date Like'%'+@DateBlackMenue+'%'";
                SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                // bool state = false;
                cmd.Parameters.AddWithValue("@IsInBlackMenue", true);
                cmd.Parameters.AddWithValue("@DateBlackMenue","26/9/2020");
                cmd.ExecuteNonQuery();
            }
            dbcon.conclose();

            filltextloanlater();
        }




        public void Cancel_copy_reserved()
        {



            DataTable dt = b.Update_avaliable_number(canceling_date.Text);
            foreach (DataRow dr in dt.Rows)
            {
                //book_id,book_num,book_name,dirctory_num,part_num,lcat_num,type_id,author_id,translator_id,producing_num,producing_date,copies_num,book_state
                //,examiner_id,language_id,publisher_id,room_num,floor_num,wheel_num,shelf_num,discription)
                int book_id = Convert.ToInt32(dr["book_id"].ToString());
                try
                {
                    dbcon.conOpen();
                    MessageBox.Show(book_id.ToString());
                    SqlCommand cmd = new SqlCommand(" select avaliablecopies_num from  tblbook where book_id =@book_id", dbcon.Con);
                    //cmd.Parameters.AddWithValue("@reserve_date", reserve_date.Text);
                    cmd.Parameters.AddWithValue("@book_id", book_id);
                    SqlDataReader Ra = cmd.ExecuteReader();
                    Ra.Read();
                    int num = Convert.ToInt32(Ra[0].ToString());

                    dbcon.conclose();
                    Ra.Close();




                    dbcon.conOpen();
                    if (dbcon.Con != null)
                    {
                        string query = "UPDATE tblbook SET avaliablecopies_num = @num  WHERE book_id =@book_id";
                        SqlCommand cmd1 = new SqlCommand(query, dbcon.Con);
                        // bool state = false;
                        cmd1.Parameters.AddWithValue("@num", num + 1);
                        cmd1.Parameters.AddWithValue("@book_id", book_id);
                        cmd1.ExecuteNonQuery();
                    }
                    dbcon.conclose();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }




        private void btn_backmenu_Click(object sender, RoutedEventArgs e)
        {
            grid_notf.Visibility = Visibility.Collapsed;
            GridMain.Visibility = Visibility.Visible;
            notification.Visibility = Visibility.Visible;
            btn_backmenu.Visibility = Visibility.Collapsed;
            fillnotuficationsnumber();
        }

        private void notification_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl uc = new UserControlNotifications();
            grid_notf.Children.Clear();
            grid_notf.Children.Add(uc);
            grid_notf.Visibility = Visibility.Visible;
            notification.Visibility = Visibility.Collapsed;
            GridMain.Visibility = Visibility.Collapsed;
            btn_backmenu.Visibility = Visibility.Visible;

        }

        private void btn_lateborrowing_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_log_out_Click(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

      

        private void btn_refresh_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            look_for_laters();
            Cancel_copy_reserved();
            b.update_reserving_state(canceling_date.Text);
            //update avaliablecopies_number
            //delete requests
            b.cancel_request(canceling_date.Text);

            filltextcopyborrowed();
            filltextloanlater();
            fillnotuficationsnumber();
            filltextborrowernumber();
            look_for_blackloans();
            // Dt = cl.GET_All_laters();
            dg_loanlater.ItemsSource = b.GET_AllLoans_inblack().DefaultView;
        }
    }

}

