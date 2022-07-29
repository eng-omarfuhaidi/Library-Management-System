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
    /// Interaction logic for UserControlAddCatogray.xaml
    /// </summary>
    public partial class UserControlAddCatogray : UserControl
    {
        DAL.DbConnection dbcon = new DAL.DbConnection();
        public UserControlAddCatogray()
        {
            InitializeComponent();
            load_grid();
            btn_savecat.IsEnabled = false;
        }
        private void load_grid()
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
                    string q = "SELECT lcat_num AS 'المحلي' , icat_num  AS 'العالمي', cat_name AS 'الاسم', arcat_sym AS 'الرمز العربي' , encat_sym AS 'الرمز الانجليزي' FROM tblcatogray ";
                    SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dg_catogray.ItemsSource = dt.DefaultView;





                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            dbcon.conclose();
        }

        private void clearcontrols()
        {
            txt_loc_catogray.Text = "";
            txt_int_catogray.Text = "";
            txt_catograyname.Text = "";
            txt_arcatsymple.Text = "";
            txt_encatsymple.Text = "";
        }
        private void btn_newcat_Click(object sender, RoutedEventArgs e)
        {
           clearcontrols();
            enabledNewTransbutton();
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (lcat_num)+1,1) from tblcatogray", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_loc_catogray.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
            btn_savecat.IsEnabled = true;
        }

        private void btn_savecat_Click(object sender, RoutedEventArgs e)
        {


            if (txt_loc_catogray.Text.Trim() == "" || txt_int_catogray.Text.Trim() == "" || txt_catograyname.Text == "" || txt_arcatsymple.Text == "" || txt_encatsymple.Text == "")
            {
                MessageBox.Show("يجب ملئ الحقول الفارغة");
                return;
            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                //let's check first if the data trying to change is already exist.
                string check = "SELECT TOP 1 * FROM tblcatogray WHERE lcat_num = @lcat_num";
                SqlCommand cmdcheck = new SqlCommand(check, dbcon.Con);
                cmdcheck.Parameters.AddWithValue("@lcat_num", txt_loc_catogray.Text.Trim());
                SqlDataReader sdr = cmdcheck.ExecuteReader();

                if (sdr.Read()) //if theres a record, return, meaning we cannot allow it
                {
                    MessageBox.Show("رقم التصنيف المحلي مكرر");
                    sdr.Close();
                    return;
                }
                else //we can add or insert it
                {
                    sdr.Close();
                    SqlCommand cmd = new SqlCommand(" insert into tblcatogray Values(@lcat_num,@icat_num,@cat_name,@arcat_sym,@encat_sym)", dbcon.Con);
                    cmd.Parameters.AddWithValue("@lcat_num", txt_loc_catogray.Text.Trim());
                    cmd.Parameters.AddWithValue("@icat_num", txt_int_catogray.Text.Trim());
                    cmd.Parameters.AddWithValue("@cat_name", txt_catograyname.Text.Trim());
                    cmd.Parameters.AddWithValue("@arcat_sym", txt_arcatsymple.Text.Trim());
                    cmd.Parameters.AddWithValue("@encat_sym", txt_encatsymple.Text.Trim());
                    cmd.ExecuteNonQuery();
                    // loadgrid();
                    // enabledNewTransbutton();
                    clearcontrols();
                    //con = new SqlConnection();
                    dbcon.conclose();
                    //   btn_can_(sender, e);
                    MessageBox.Show("تم الحفظ");

                }
                load_grid();
            }
        }

        private void dg_catogray_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dg_catogray.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_catogray.SelectedItems[0];
                txt_loc_catogray.Text = x[0].ToString();
                txt_int_catogray.Text = x[1].ToString();
                txt_catograyname.Text = x[2].ToString();
                txt_arcatsymple.Text = x[3].ToString();
                txt_encatsymple.Text = x[4].ToString();
                modifyTrans();

            }
            else
            {
                MessageBox.Show("اضغط فوق الحقول الممتلئة");
                return;
            }

        }

        private void enabledNewTransbutton()
        {



            btn_savecat.IsEnabled = false;
            btn_delete.IsEnabled = false;
            btn_update.IsEnabled = false;
            btn_newcat.IsEnabled = true;
        }
        private void modifyTrans()
        {



            btn_update.IsEnabled = true;
            btn_delete.IsEnabled = true;
            btn_savecat.IsEnabled = false;

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //let's check first if the textboxes are empty since we cannot allow a blank data
                if (txt_loc_catogray.Text.Trim() == "" || txt_int_catogray.Text.Trim() == "" || txt_catograyname.Text == "" || txt_arcatsymple.Text == "" || txt_encatsymple.Text == "")
                {
                    MessageBox.Show("يجب ملئ الحقول");
                    return;
                }
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "UPDATE tblcatogray SET lcat_num = @lcat_num ,icat_num = @icat_num, cat_name = @cat_name, arcat_sym = @arcat_sym ,encat_sym=@encat_sym WHERE lcat_num=@lcat_num";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                    cmd.Parameters.AddWithValue("@lcat_num", txt_loc_catogray.Text.Trim());
                    cmd.Parameters.AddWithValue("@icat_num", txt_int_catogray.Text.Trim());
                    cmd.Parameters.AddWithValue("@cat_name", txt_catograyname.Text.Trim());
                    cmd.Parameters.AddWithValue("@arcat_sym", txt_arcatsymple.Text.Trim());
                    cmd.Parameters.AddWithValue("@encat_sym", txt_encatsymple.Text.Trim());


                    //cmd.Parameters.AddWithValue("@stocks", txtbStocks.Text.Trim());

                    cmd.ExecuteNonQuery();
                    load_grid();
                    enabledNewTransbutton();
                    clearcontrols();
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

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {

            try
            {


                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "DELETE FROM tblcatogray WHERE lcat_num = @lcat_num";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                    cmd.Parameters.AddWithValue("@lcat_num", txt_loc_catogray.Text.Trim());
                    cmd.ExecuteNonQuery();
                    load_grid();
                    enabledNewTransbutton();
                    clearcontrols();
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

        private void txt_searching_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_block.Visibility = Visibility.Hidden;
        }

        private void txt_searching_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txt_searching.Text == "")
            {
                txt_block.Visibility = Visibility.Visible;
            }
      
        
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
                _condition = "WHERE lcat_num LIKE '%" + @value + "%' OR icat_num LIKE '%" + @value + "%' OR cat_name LIKE '%" + @value + "%'";


            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * from tblcatogray " + _condition;
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                cmd.Parameters.AddWithValue("@value", value);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dg_catogray.ItemsSource = dt.DefaultView;
              //  dg_catogray.Columns[0].Visibility = Visibility.Collapsed;
               // dg_catogray.Columns[2].Visibility = Visibility.Collapsed;
                dg_catogray.Columns[0].Header = "الرقم المحلي";
                dg_catogray.Columns[1].Header = "الرقم العالمي";
                dg_catogray.Columns[2].Header = "الاسم";
                dg_catogray.Columns[3].Header = "AR/الرمز";
                dg_catogray.Columns[4].Header = "EN/الرمز";
            }
            else
            {
                return;
            }
            dbcon.conclose();
        }

        private void txt_searching_TextChanged(object sender, TextChangedEventArgs e)
        {
            text_searching(txt_searching.Text.Trim());
        }
    }
}


        
    

