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
    /// Interaction logic for UserControlAddTranslator.xaml
    /// </summary>
    public partial class UserControlAddTranslator : UserControl
    {
        DAL.DbConnection dbcon = new DAL.DbConnection();
        public UserControlAddTranslator()
        {
            InitializeComponent();
            load_translatorgrid();
        }
        private void clearControls()
        {
            txt_translator_id.Text = "";
            txt_translatorname.Text = "";


        }

        private void enabledNewTransbutton()
        {



            btn_savetranslator.IsEnabled = true;
            btn_deletetranslator.IsEnabled = false;
            btn_updatetranslator.IsEnabled = false;
            btn_addnewltanslator.IsEnabled = true;
         
        }
        private void modifyTrans()
        {
            btn_updatetranslator.IsEnabled = true;
            btn_deletetranslator.IsEnabled = true;
            btn_savetranslator.IsEnabled = false;
        }
        private void load_translatorgrid()
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

                    string q = "select translator_id AS 'رقم التسجيل' , translator_name AS 'اسم المترجم'  from tbltranslator";
                    SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dg_translator.ItemsSource = dt.DefaultView;






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
                _condition = "WHERE translator_name LIKE '%" + @value + "%'";


            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * from tbltranslator " + _condition;
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                cmd.Parameters.AddWithValue("@value", value);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dg_translator.ItemsSource = dt.DefaultView;
                dg_translator.Columns[0].Header = "رقم التسجيل";
                dg_translator.Columns[1].Header = "اسم المحقق";


            }
            else
            {
                return;
            }
            dbcon.conclose();
        }

        private void btn_addnewltanslator_Click(object sender, RoutedEventArgs e)
        {
            clearControls();
            enabledNewTransbutton();
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (translator_id)+1,1) from tbltranslator", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_translator_id.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
        }

        private void btn_savetranslator_Click(object sender, RoutedEventArgs e)
        {

            if (txt_translatorname.Text.Trim() == "")
            {
                MessageBox.Show("يجب ملئ الحقول الفارغة");
                return;
            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                SqlCommand cmd = new SqlCommand(" insert into tbltranslator Values(@translator_id,@translator_name)", dbcon.Con);
                cmd.Parameters.AddWithValue("@translator_id", txt_translator_id.Text.Trim());
                cmd.Parameters.AddWithValue("@translator_name",txt_translatorname.Text.Trim());


                cmd.ExecuteNonQuery();
                // loadgrid();
                enabledNewTransbutton();
                clearControls();
                //con = new SqlConnection();
                dbcon.conclose();
                //   btn_can_(sender, e);
                MessageBox.Show("تم الحفظ");

            }
            load_translatorgrid();
        }

        private void btn_updatetranslator_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //let's check first if the textboxes are empty since we cannot allow a blank data
                if (txt_translatorname.Text.Trim() == "")
                {
                    MessageBox.Show("يجب ملئ الحقول");
                    return;
                }
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "UPDATE tbltranslator SET translator_name = @translator_name  WHERE translator_id=@translator_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);

                    cmd.Parameters.AddWithValue("@translator_name", txt_translatorname.Text.Trim());
                    cmd.Parameters.AddWithValue("@translator_id", txt_translator_id.Text.Trim());



                    //cmd.Parameters.AddWithValue("@stocks", txtbStocks.Text.Trim());

                    cmd.ExecuteNonQuery();
                    load_translatorgrid();
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

        private void btn_deletetranslator_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "DELETE FROM tbltranslator WHERE translator_id = @translator_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                    cmd.Parameters.AddWithValue("@translator_id", txt_translator_id.Text.Trim());
                    cmd.ExecuteNonQuery();
                    load_translatorgrid();
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

        private void txt_searchtranslator_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_block.Text=="")
            {
                txt_block.Visibility = Visibility.Visible;

            }

        }

        private void txt_searchtranslator_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_block.Visibility = Visibility.Hidden;

        }

        private void txt_searchtranslator_TextChanged(object sender, TextChangedEventArgs e)
        {
            text_searching(txt_searchtranslator.Text.Trim());
        }

        private void dg_translator_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (dg_translator.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_translator.SelectedItems[0];
                txt_translator_id.Text = x[0].ToString();
                txt_translatorname.Text = x[1].ToString();
                modifyTrans();

            }
            
        }
    }
}
