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
    /// Interaction logic for UserControlAddLanguage.xaml
    /// </summary>
    public partial class UserControlAddLanguage : UserControl
    {
        DAL.DbConnection dbcon = new DAL.DbConnection();
        public UserControlAddLanguage()
        {
            InitializeComponent();
            load_languagegrid();
        }

        private void clearControls()
        { 
            txt_language_id.Text = "";
            txt_languagename.Text = "";
           

        }

        private void enabledNewTransbutton()
        {



            btn_savelanguage.IsEnabled = true;
            btn_deletelanguage.IsEnabled = false;
            btn_updatelanguage.IsEnabled = false;
            btn_addnewlanguage.IsEnabled = true;
          
        }
        private void modifyTrans()
        {
            btn_updatelanguage.IsEnabled = true;
            btn_deletelanguage.IsEnabled = true;
            btn_savelanguage.IsEnabled = false;
        }
        private void load_languagegrid()
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
                   
                    string q = "select language_id AS 'رقم التسجيل' , language_name AS 'اسم اللغة'  from tbllanguage";
                    SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                   dg_language.ItemsSource = dt.DefaultView;
                 





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
                _condition = "WHERE language_name LIKE '%" + @value + "%'";


            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * from tbllanguage " + _condition;
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                cmd.Parameters.AddWithValue("@value", value);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dg_language.ItemsSource = dt.DefaultView;
                dg_language.Columns[0].Header = "رقم التسجيل";
                dg_language.Columns[1].Header = "اسم اللغة";
               

            }
            else
            {
                return;
            }
            dbcon.conclose();
        }
      

        private void txt_searchlanguage_GotFocus(object sender, RoutedEventArgs e)
        {

            txt_block.Visibility = Visibility.Hidden;
        }

        private void txt_searchlanguage_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txt_searchlanguage.Text=="") 
            {
                txt_block.Visibility = Visibility.Visible;
            }
        }

        private void txt_searchlanguage_TextChanged(object sender, TextChangedEventArgs e)
        {
            text_searching(txt_searchlanguage.Text.Trim());
        }

        private void btn_updatelanguage_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //let's check first if the textboxes are empty since we cannot allow a blank data
                if (txt_languagename.Text.Trim() == "")
                {
                    MessageBox.Show("يجب ملئ الحقول");
                    return;
                }
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "UPDATE tbllanguage SET language_name = @language_name  WHERE language_id=@language_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);

                    cmd.Parameters.AddWithValue("@language_name", txt_languagename.Text.Trim());
                    cmd.Parameters.AddWithValue("@language_id", txt_language_id.Text.Trim());



                    //cmd.Parameters.AddWithValue("@stocks", txtbStocks.Text.Trim());

                    cmd.ExecuteNonQuery();
                    load_languagegrid();
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

        private void dg_language_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (dg_language.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_language.SelectedItems[0];
                txt_language_id.Text = x[0].ToString();
                txt_languagename.Text = x[1].ToString();
                modifyTrans();

            }
            else
            {
                MessageBox.Show("اضغط فوق الحقول الممتلئة");
                return;
            }
        }

        private void btn_deletelanguage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "DELETE FROM tbllanguage WHERE language_id = @language_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                    cmd.Parameters.AddWithValue("@language_id", txt_language_id.Text.Trim());
                    cmd.ExecuteNonQuery();
                    load_languagegrid();
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

        private void btn_addnewlanguage_Click(object sender, RoutedEventArgs e)
        {


            clearControls();
            enabledNewTransbutton();
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (language_id)+1,1) from tbllanguage", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_language_id.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
        }

        private void btn_savelanguage_Click(object sender, RoutedEventArgs e)
        {

            if (txt_languagename.Text.Trim() == "")
            {
                MessageBox.Show("يجب ملئ الحقول الفارغة");
                return;
            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                SqlCommand cmd = new SqlCommand(" insert into tbllanguage Values(@language_id,@language_name)", dbcon.Con);
                cmd.Parameters.AddWithValue("@language_id", txt_language_id.Text.Trim());
                cmd.Parameters.AddWithValue("@language_name",txt_languagename.Text.Trim());


                cmd.ExecuteNonQuery();
                // loadgrid();
                enabledNewTransbutton();
                clearControls();
                //con = new SqlConnection();
                dbcon.conclose();
                //   btn_can_(sender, e);
                MessageBox.Show("تم الحفظ");

            }
            load_languagegrid();
        }
    }
    }

