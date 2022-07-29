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
    /// Interaction logic for UserControlِAddType.xaml
    /// </summary>
    public partial class UserControlAddType : UserControl
    {
        DAL.DbConnection dbcon = new DAL.DbConnection();
        public UserControlAddType()
        {
            InitializeComponent();
            load_typegrid();
        }

        private void enabledNewTransbutton()
        {



            btn_savetype.IsEnabled = true;
            btn_deletetype.IsEnabled = false;
            btn_updatetype.IsEnabled = false;
            btn_newtype.IsEnabled = true;
          
        }

        private void modifyTrans()
        {
            btn_updatetype.IsEnabled = true;
            btn_deletetype.IsEnabled = true;
            btn_savetype.IsEnabled = false;
        }

        private void clearControls()
        {

            txt_typeid.Text = "";
            txt_typename.Text = "";
            txt_typedisc.Text = "";

        }
        private void load_typegrid()
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
                    string q = "select type_id AS 'رقم التسجيل' ,type_name AS 'اسم النوع' , type_disc AS 'وصف النوع' from tbltype";
                    SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dg_type.ItemsSource = dt.DefaultView;


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
                _condition = "WHERE type_name LIKE '%" + @value + "%' OR type_disc LIKE '%" + @value + "%'";


            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * from tbltype " + _condition;
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                cmd.Parameters.AddWithValue("@value", value);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dg_type.ItemsSource = dt.DefaultView;
                dg_type.Columns[0].Header = "رقم التسجيل";
                dg_type.Columns[1].Header = "اسم النوع";
                dg_type.Columns[2].Header = "وصف النوع";

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

        private void txt_typesearch_LostFocus(object sender, RoutedEventArgs e)
        {

            if (txt_typesearch.Text == "")
            {
                txt_block.Visibility = Visibility.Visible;
            }
        }



        private void txt_publishersearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            text_searching(txt_typesearch.Text.Trim());
        }

        private void dg_publisher_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (dg_type.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_type.SelectedItems[0];
                txt_typeid.Text = x[0].ToString();
                txt_typename.Text = x[1].ToString();
                txt_typedisc.Text = x[2].ToString();
                modifyTrans();

            }
            else
            {
                MessageBox.Show("اضغط فوق الحقول الممتلئة");
                return;
            }
        }



        private void txt_typesearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_block.Visibility = Visibility.Hidden;
        }



        private void txt_typesearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            text_searching(txt_typesearch.Text.Trim());
        }

        private void txt_typesearch_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (txt_typesearch.Text == "")
            {
                txt_block.Visibility = Visibility.Visible;
            }
        }

        private void btn_newtype_Click(object sender, RoutedEventArgs e)
        {

            clearControls();
            enabledNewTransbutton();
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (type_id)+1,1) from tbltype", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_typeid.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
        }

        private void btn_savetype_Click(object sender, RoutedEventArgs e)
        {

            if (txt_typename.Text.Trim() == "")
            {
                MessageBox.Show("يجب ملئ الحقول الفارغة");
                return;
            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                SqlCommand cmd = new SqlCommand(" insert into tbltype Values(@type_id,@type_name,@type_disc)", dbcon.Con);
                cmd.Parameters.AddWithValue("@type_id", txt_typeid.Text.Trim());
                cmd.Parameters.AddWithValue("@type_name", txt_typename.Text.Trim());
                cmd.Parameters.AddWithValue("@type_disc", txt_typedisc.Text.Trim());
                cmd.ExecuteNonQuery();
                // loadgrid();
                enabledNewTransbutton();
                clearControls();
                //con = new SqlConnection();
                dbcon.conclose();
                //   btn_can_(sender, e);
                MessageBox.Show("تم الحفظ");

            }
            load_typegrid();
        }

        private void btn_updatetype_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //let's check first if the textboxes are empty since we cannot allow a blank data
                if (txt_typename.Text.Trim() == "")
                {
                    MessageBox.Show("يجب ملئ الحقول");
                    return;
                }
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "UPDATE tbltype SET type_name = @type_name ,type_disc = @type_disc WHERE type_id=@type_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);

                    cmd.Parameters.AddWithValue("@type_name", txt_typename.Text.Trim());
                    cmd.Parameters.AddWithValue("@type_disc", txt_typedisc.Text.Trim());
                    cmd.Parameters.AddWithValue("@type_id", txt_typeid.Text.Trim());



                    //cmd.Parameters.AddWithValue("@stocks", txtbStocks.Text.Trim());

                    cmd.ExecuteNonQuery();
                    load_typegrid();
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

        private void btn_deletetype_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "DELETE FROM tbltype WHERE type_id = @type_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                    cmd.Parameters.AddWithValue("@type_id", txt_typeid.Text.Trim());
                    cmd.ExecuteNonQuery();
                 load_typegrid();
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
