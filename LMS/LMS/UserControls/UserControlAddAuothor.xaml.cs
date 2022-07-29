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
using LMS.DAL;

namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControl2AddAuothor.xaml
    /// </summary>
    public partial class UserControlAddAuothor : UserControl
    {
        DbConnection dbcon = new DbConnection();
        public UserControlAddAuothor()
        {
            InitializeComponent();
            load_authorgrid();
        }

         private void modifyTrans()
        {
            btn_updateauthor.IsEnabled = true;
            btn_deleteauthor.IsEnabled = true;
            btn_saveauthor.IsEnabled = false;
        }

        private void load_authorgrid()
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
                    string q = "select author_id AS 'رقم التسجيل' , author_name AS 'اسم المؤلف' , author_disc AS 'وصف المؤلف' from tblauthor";
                    SqlCommand cmd = new SqlCommand(q,dbcon.Con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dg_author.ItemsSource = dt.DefaultView;
                   /*dg_author.Columns[0].Visibility = Visibility.Collapsed;
                    dg_author.Columns[0].Header = "رقم التسجيل ";
                    dg_author.Columns[1].Header = "اسم المؤلف";
                    dg_author.Columns[2].Header = "وصف المؤلف";
                 */





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
                _condition = "WHERE author_name LIKE '%" + @value + "%' OR author_disc LIKE '%" + @value + "%'";


            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * from tblauthor " + _condition;
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                cmd.Parameters.AddWithValue("@value", value);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dg_author.ItemsSource = dt.DefaultView;
                //  dg_catogray.Columns[0].Visibility = Visibility.Collapsed;
                // dg_catogray.Columns[2].Visibility = Visibility.Collapsed;
                dg_author.Columns[0].Header = "رقم التسجيل";
                dg_author.Columns[1].Header = "اسم المؤلف";
                dg_author.Columns[2].Header = "وصف المؤلف";
             
            }
            else
            {
                return;
            }
            dbcon.conclose();
        }

        private void txt_authorsearching_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_block.Visibility = Visibility.Hidden;

        }

        private void txt_authorsearching_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txt_authorsearching.Text == "")
            {
                txt_block.Visibility = Visibility.Visible;
            }
        }

        private void txt_authorsearching_TextChanged(object sender, TextChangedEventArgs e)
        {
            text_searching(txt_authorsearching.Text.Trim());
        }


        private void btn_newauthor_Click(object sender, RoutedEventArgs e)
        {

            clearControls();
            enabledNewTransbutton();
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (author_id)+1,1) from tblauthor", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_authornum.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
        }
      private void  clearControls()
        {

            txt_authornum.Text = "";
            txt_authorname.Text = "";
            txt_authordisc.Text = "";
           
        }
        private void enabledNewTransbutton()
        {


         
            btn_saveauthor.IsEnabled = true;
            btn_deleteauthor.IsEnabled = false;
            btn_updateauthor.IsEnabled = false;
            btn_newauthor.IsEnabled = true;
           
        }

        private void btn_saveauthor_Click(object sender, RoutedEventArgs e)
        {

            if (txt_authorname.Text.Trim() == "" )
            {
                MessageBox.Show("يجب ملئ الحقول الفارغة");
                return;
            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            { 
                    SqlCommand cmd = new SqlCommand(" insert into tblauthor Values(@author_id,@author_name,@author_disc)", dbcon.Con);
                    cmd.Parameters.AddWithValue("@author_id", txt_authornum.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_name", txt_authorname.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_disc", txt_authordisc.Text.Trim());
                 
                    cmd.ExecuteNonQuery();
                    // loadgrid();
                     enabledNewTransbutton();
                    clearControls();
                    //con = new SqlConnection();
                    dbcon.conclose();
                    //   btn_can_(sender, e);
                    MessageBox.Show("تم الحفظ");

                }
                load_authorgrid ();
            }

        private void btn_updateauthor_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //let's check first if the textboxes are empty since we cannot allow a blank data
                if (txt_authorname.Text.Trim() == "")
                {
                    MessageBox.Show("يجب ملئ الحقول");
                    return;
                }
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "UPDATE tblauthor SET author_name = @author_name ,author_disc = @author_disc WHERE author_id=@author_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);

                    cmd.Parameters.AddWithValue("@author_name", txt_authorname.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_disc", txt_authordisc.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_id", txt_authornum.Text.Trim());



                    //cmd.Parameters.AddWithValue("@stocks", txtbStocks.Text.Trim());

                    cmd.ExecuteNonQuery();
                    load_authorgrid();
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

        private void dg_author_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (dg_author.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_author.SelectedItems[0];
                txt_authornum.Text = x[0].ToString();
                txt_authorname.Text = x[1].ToString();
                txt_authordisc.Text = x[2].ToString();
                modifyTrans();

            }
            else
            {
                MessageBox.Show("اضغط فوق الحقول الممتلئة");
                return;
            }
        }

        private void btn_deleteauthor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "DELETE FROM tblauthor WHERE author_id = @author_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                    cmd.Parameters.AddWithValue("@author_id", txt_authornum.Text.Trim());
                    cmd.ExecuteNonQuery();
                    load_authorgrid();
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

