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
using System.Data.SqlClient;
using System.Data;

namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControlAddPublisher.xaml
    /// </summary>
    public partial class UserControlAddPublisher : UserControl
    {
        DAL.DbConnection dbcon = new DAL.DbConnection();
        public UserControlAddPublisher()
        {
            InitializeComponent();
            load_publishergrid();

        }


        private void enabledNewTransbutton()
        {



            btn_savepublisher.IsEnabled = true;
            btn_deletepublisher.IsEnabled = false;
            btn_updatepublisher.IsEnabled = false;
            btn_newpublisher.IsEnabled = true;
           
        }

        private void modifyTrans()
        {
            btn_updatepublisher.IsEnabled = true;
            btn_deletepublisher.IsEnabled = true;
            btn_savepublisher.IsEnabled = false;
        }

        private void clearControls()
        {

            txt_publisherid.Text = "";
            txt_publishername.Text = "";
            txt_pulisherdisc.Text = "";

        }
        private void load_publishergrid()
        {
            dbcon.conOpen();
            if (dbcon == null)
            {
                return;
            }
            else
            {

                try
                {
                    //Pass_word , loc_catog_num ,int_catog_num , catog_name,ar_catog_symple ,en_catog_symple
                    string q = "select publisher_id AS 'رقم التسجيل' , publisher_name AS 'اسم الناشر' , publisher_disc AS 'وصف الناشر' from tblpublisher";
                    SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dg_publisher.ItemsSource = dt.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            dbcon.conclose();
        }


        private void text_searching(string value)
        {
            var _condition = "";
            if (value == "")
            {
                _condition = "";
            }
            else
            {
                _condition = "WHERE publisher_name LIKE '%" + @value + "%' OR publisher_disc LIKE '%" + @value + "%'";


            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * from tblpublisher " + _condition;
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                cmd.Parameters.AddWithValue("@value", value);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dg_publisher.ItemsSource = dt.DefaultView;
                dg_publisher.Columns[0].Header = "رقم التسجيل";
                dg_publisher.Columns[1].Header = "اسم الناشر";
                dg_publisher.Columns[2].Header = "وصف الناشر";

            }
            else
            {
                return;
            }
            dbcon.conclose();
        }

        private void txt_publishersearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_block.Visibility = Visibility.Hidden;
        }

        private void txt_publishersearch_LostFocus(object sender, RoutedEventArgs e)
        {

            if (txt_publishersearch.Text == "")
            {
                txt_block.Visibility = Visibility.Visible;
            }
        }



        private void txt_publishersearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            text_searching(txt_publishersearch.Text.Trim());
        }

        private void dg_publisher_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (dg_publisher.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_publisher.SelectedItems[0];
                txt_publisherid.Text = x[0].ToString();
                txt_publishername.Text = x[1].ToString();
                txt_pulisherdisc.Text = x[2].ToString();
                modifyTrans();

            }

        }
        private void btn_newpublisher_Click(object sender, RoutedEventArgs e)
        {

            clearControls();
            enabledNewTransbutton();
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (publisher_id)+1,1) from tblpublisher", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_publisherid.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
        }

        private void btn_savepublisher_Click(object sender, RoutedEventArgs e)
        {

            if (txt_publishername.Text.Trim() == "")
            {
                MessageBox.Show("يجب ملئ الحقول الفارغة");
                return;
            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                SqlCommand cmd = new SqlCommand(" insert into tblpublisher Values(@publisher_id,@publisher_name,@publisher_disc)", dbcon.Con);
                cmd.Parameters.AddWithValue("@publisher_id", txt_publisherid.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", txt_publishername.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_disc", txt_pulisherdisc.Text.Trim());
                cmd.ExecuteNonQuery();
                // loadgrid();
                enabledNewTransbutton();
                clearControls();
                //con = new SqlConnection();
                dbcon.conclose();
                //   btn_can_(sender, e);
                MessageBox.Show("تم الحفظ");

            }
            load_publishergrid();
        }

        private void btn_updatepublisher_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //let's check first if the textboxes are empty since we cannot allow a blank data
                if (txt_publishername.Text.Trim() == "")
                {
                    MessageBox.Show("يجب ملئ الحقول");
                    return;
                }
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "UPDATE tblpublisher SET publisher_name = @publisher_name ,publisher_disc = @publisher_disc WHERE publisher_id=@publisher_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);

                    cmd.Parameters.AddWithValue("@publisher_name", txt_publishername.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher_disc", txt_pulisherdisc.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher_id", txt_publisherid.Text.Trim());



                    //cmd.Parameters.AddWithValue("@stocks", txtbStocks.Text.Trim());

                    cmd.ExecuteNonQuery();
                    load_publishergrid();
                    enabledNewTransbutton();
                    clearControls();
                    MessageBox.Show("تم التعديل بنجاح");
                }



                else
                {
                    return;
                }
                dbcon.conclose();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_deletepublisher_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "DELETE FROM tblpublisher" +
                        " WHERE publisher_id = @publisher_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                    cmd.Parameters.AddWithValue("@publisher_id", txt_publisherid.Text.Trim());
                    cmd.ExecuteNonQuery();
                    load_publishergrid();
                    enabledNewTransbutton();
                    clearControls();
                    MessageBox.Show("تم الحذف بنجاح");
                }


                else
                {
                    return;
                }
                dbcon.conclose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    } 
    }



