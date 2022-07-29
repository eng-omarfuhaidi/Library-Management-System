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
    /// Interaction logic for UserControlAddExaminer.xaml
    /// </summary>
    public partial class UserControlAddExaminer : UserControl
    {
        DAL.DbConnection dbcon = new DAL.DbConnection();
        public UserControlAddExaminer()
        {
            InitializeComponent();
            load_examinergrid();

        }


        private void clearControls()
        {
            txt_examinerid.Text = "";
            txt_examinername.Text = "";
            load_examinergrid();

        }

        private void enabledNewTransbutton()
        {



            btn_savelexaminer.IsEnabled = true;
            btn_deleteexaminer.IsEnabled = false;
            btn_updateexaminer.IsEnabled = false;
            btn_addnewexaminer.IsEnabled = true;
          
        }
        private void modifyTrans()
        {
            btn_updateexaminer.IsEnabled = true;
            btn_deleteexaminer.IsEnabled = true;
            btn_savelexaminer.IsEnabled = false;
        }
        private void load_examinergrid()
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

                    string q = "select examiner_id AS 'رقم التسجيل' , examiner_name AS 'اسم المحقق'  from tblexaminer";
                    SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dg_examiner.ItemsSource = dt.DefaultView;






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
                _condition = "WHERE examiner_name LIKE '%" + @value + "%'";


            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            { 
                string q = "SELECT * from tblexaminer " + _condition;
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                cmd.Parameters.AddWithValue("@value", value);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dg_examiner.ItemsSource = dt.DefaultView;
                dg_examiner.Columns[0].Header = "رقم التسجيل";
                dg_examiner.Columns[1].Header = "اسم المحقق";


            }
            else
            {
                return;
            }
            dbcon.conclose();
        }
        private void btn_addnewexaminer_Click(object sender, RoutedEventArgs e)
        {

            clearControls();
            enabledNewTransbutton();
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (examiner_id)+1,1) from tblexaminer", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_examinerid.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
        }

        private void btn_savelexaminer_Click(object sender, RoutedEventArgs e)
        {

            if (txt_examinername.Text.Trim() == "")
            {
                MessageBox.Show("يجب ملئ الحقول الفارغة");
                return;
            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                SqlCommand cmd = new SqlCommand(" insert into tblexaminer Values(@examiner_id,@examiner_name)", dbcon.Con);
                cmd.Parameters.AddWithValue("@examiner_id",  txt_examinerid.Text.Trim());
                cmd.Parameters.AddWithValue("@examiner_name", txt_examinername.Text.Trim());


                cmd.ExecuteNonQuery();
                // loadgrid();
                enabledNewTransbutton();
                clearControls();
                //con = new SqlConnection();
                dbcon.conclose();
                //   btn_can_(sender, e);
                MessageBox.Show("تم الحفظ");

            }
            load_examinergrid ();

        }

        private void btn_updateexaminer_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //let's check first if the textboxes are empty since we cannot allow a blank data
                if (txt_examinername.Text.Trim() == "")
                {
                    MessageBox.Show("يجب ملئ الحقول");
                    return;
                }
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "UPDATE tblexaminer SET examiner_name = @examiner_name  WHERE examiner_id=@examiner_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);

                    cmd.Parameters.AddWithValue("@examiner_name", txt_examinername.Text.Trim());
                    cmd.Parameters.AddWithValue("@examiner_id", txt_examinerid.Text.Trim());



                    //cmd.Parameters.AddWithValue("@stocks", txtbStocks.Text.Trim());

                    cmd.ExecuteNonQuery();
                    load_examinergrid();
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

        private void btn_deleteexaminer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "DELETE FROM tblexaminer WHERE examiner_id = @examiner_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                    cmd.Parameters.AddWithValue("@language_id", txt_examinerid.Text.Trim());
                    cmd.ExecuteNonQuery();
                    load_examinergrid();
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

        private void txt_searchexaminer_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_block.Visibility = Visibility.Hidden;
        }

        private void txt_searchexaminer_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_searchexaminer.Text == "")
            {
                txt_block.Visibility = Visibility.Visible;
            }
        }

        private void txt_searchexaminer_TextChanged(object sender, TextChangedEventArgs e)
        {

            text_searching(txt_searchexaminer.Text.Trim());
        }

        private void dg_examiner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dg_examiner.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_examiner.SelectedItems[0];
                txt_examinerid.Text = x[0].ToString();
                txt_examinername.Text = x[1].ToString();
                modifyTrans();

            }
            else
            {
                MessageBox.Show("اضغط فوق الحقول الممتلئة");
                return;
            }

        }

       
    }
}
