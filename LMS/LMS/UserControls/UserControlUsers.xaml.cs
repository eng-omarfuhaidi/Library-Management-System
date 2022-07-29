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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using MessageBox = System.Windows.Forms.MessageBox;

namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControlUsers.xaml
    /// </summary>
    public partial class UserControlUsers : UserControl
    {
        DAL.DbConnection dbcon = new DAL.DbConnection();
        List<string> list = new List<string>();

        public UserControlUsers()
        {

            InitializeComponent();
            loadgrid();
   
            btn_SAVE1.IsEnabled = false;
           
        }


        private void loadgrid()
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
                    string q = "SELECT Pass_word , User_name_login , User_name , User_ID  FROM TB_Users ";
                    SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dg_users.ItemsSource = dt.DefaultView;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            dbcon.conclose();
        }






        void btn_NEW_Click(object sender, RoutedEventArgs e)
        {
            
            clearControls();
            enabledNewTransbutton();
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (User_ID)+1,1) from TB_Users", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_User_ID.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
        }
        private void clearControls()
        {
            txt_User_ID.Text = "";
            txt_User_Name.Text = "";
            txt_Username_login.Text = "";
            txt_Password.Password = "";
            txt_Password2.Password = "";
            can_password.Visibility = Visibility.Visible;
        }
        private void enabledNewTransbutton()
        {


            //btn_CLOSE.IsEnabled = true;
            btn_SAVE1.IsEnabled = true;
            btn_DELET.IsEnabled = false;
            btn_UPDATE.IsEnabled = false;
            btn_NEW.IsEnabled = true;
          //  btn_can.Visibility = Visibility.Visible;
        }

       
        void btn_can_Click(object sender, RoutedEventArgs e)
        {


            txt_Password2.Visibility = Visibility.Visible;
            //lab_PASS2.Visibility = Visibility.Visible;
            //btn_CLOSE.IsEnabled = true;
            btn_SAVE1.IsEnabled = false;
            btn_DELET.IsEnabled = true;
            btn_UPDATE.IsEnabled = true;
            btn_NEW.IsEnabled = true;
          //  btn_can.Visibility = Visibility.Visible;
        }

        private void txtUBSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearchToolTip.Visibility = Visibility.Hidden;
        }

        private void txtUBSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txtUBSearch.Text == "")
            {
                txtSearchToolTip.Visibility = Visibility.Visible;
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
                _condition = "WHERE User_name LIKE '%" + @value + "%' OR User_name_login LIKE '%" + @value + "%'";


                    }

                  
                    dbcon.conOpen();
                    if (dbcon.Con != null)
                    {
                        string q = "SELECT * from TB_Users " + _condition;
                        SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                        cmd.Parameters.AddWithValue("@value", value);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dg_users.ItemsSource = dt.DefaultView;
                        /*dgBooks.Columns[0].Visibility = Visibility.Collapsed;
                        dgBooks.Columns[2].Visibility = Visibility.Collapsed;
                        dgBooks.Columns[1].Header = "Book Title";
                        dgBooks.Columns[6].Header = "Author";
                        dgBooks.Columns[3].Header = "Published";
                        dgBooks.Columns[4].Header = "Quantity";
                        dgBooks.Columns[5].Header = "Stocks";*/
                    }
                    else
                    {
                        return;
                    }
                    dbcon.conclose();
                }
           

            

        private void txtUBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            text_searching(this.txtUBSearch.Text.Trim());
        }

        private void dg_users_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dg_users.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_users.SelectedItems[0];
                txt_Password.Password = x[0].ToString();
                txt_Username_login.Text = x[1].ToString();
                txt_User_Name.Text = x[2].ToString();
                txt_User_ID.Text = x[3].ToString();




                /*
              DataTable Dt = new DataTable();
              SqlDataAdapter Da = new SqlDataAdapter(" select * from TB_Users where User_ID=" + dg_users.SelectedValuePath + " ", dbcon.Con);
              Da.Fill(Dt);

              txt_User_ID.Text = Dt.Rows[0]["User_ID"].ToString();
              txt_User_Name.Text = Dt.Rows[0]["User_name"].ToString();
              txt_Username_login.Text = Dt.Rows[0][2].ToString();
              txt_Password.Text = Dt.Rows[0][3].ToString();*/
            }
            
            modifyTrans();
        }
        private void modifyTrans()
        {



            btn_UPDATE.IsEnabled = true;
            btn_DELET.IsEnabled = true;
            btn_SAVE1.IsEnabled = false;

        }

        private void btn_UPDATE_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //let's check first if the textboxes are empty since we cannot allow a blank data
                if (txt_User_ID.Text.Trim() == null || txt_User_Name.Text.Trim() == null || txt_Username_login.Text == null || txt_Password.Password == null || txt_Password2.Password == null)
                {
                    MessageBox.Show("Book info cannot be empty");
                    return;
                }
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    //let's check first if the data trying to change is already exist.

                    string check = "SELECT TOP 1 * FROM TB_Users WHERE User_name_login = @User_name_login and User_ID <> @User_ID";
                    SqlCommand cmdcheck = new SqlCommand(check, dbcon.Con);
                    cmdcheck.Parameters.AddWithValue("@User_name_login", txt_Username_login.Text.Trim());
                    cmdcheck.Parameters.AddWithValue("@User_ID", txt_User_ID.Text.Trim());
                    SqlDataReader sdr = cmdcheck.ExecuteReader();

                    if (sdr.Read()) //if theres a record, return, meaning we cannot allow it
                    {
                        MessageBox.Show("Cannot update record, the data you are trying to change already exist.");
                        sdr.Close();
                        return;
                    }
                    else //we can change or update it
                    {
                        sdr.Close();
                        string query = "UPDATE TB_Users SET User_ID = @User_ID ,User_name = @User_name, User_name_login = @User_name_login, Pass_word = @Pass_word WHERE User_ID = @User_ID";
                        SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                        cmd.Parameters.AddWithValue("@User_ID", txt_User_ID.Text.Trim());
                        cmd.Parameters.AddWithValue("@User_name", txt_User_Name.Text.Trim());
                        cmd.Parameters.AddWithValue("@User_name_login", txt_Username_login.Text.Trim());
                        cmd.Parameters.AddWithValue("@Pass_word", txt_Password.Password.Trim());

                        //cmd.Parameters.AddWithValue("@stocks", txtbStocks.Text.Trim());

                        cmd.ExecuteNonQuery();
                        loadgrid();
                        enabledNewTransbutton();
                        clearControls();
                        MessageBox.Show("Record updated successfully");

                    }
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


        /*
private void dg_users_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
{

}*/




        private void txt_Password2_Error(object sender, ValidationErrorEventArgs e)
        {

            if (txt_Password2.Password != txt_Password.Password)
            {
                MessageBox.Show(" عذراً كلمةالمرور غير متطابقنين", "خـطأ");
                txt_Password2.Clear();
                txt_Password2.Focus();
                return;
            }
        }

        private void btn_DELET_Click(object sender, RoutedEventArgs e)
        {

            try
            {

               
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    //let's check first if the data trying to delete has a record in our main transactions.
                    /*string check = "SELECT TOP 1 * FROM tblTransaction WHERE User-ID = @id";
                    SqlCommand cmdcheck = new SqlCommand(check, dbcon.Con);
                    cmdcheck.Parameters.AddWithValue("@id", txt_User_ID.Text.Trim());
                    SqlDataReader sdr = cmdcheck.ExecuteReader();

                    if (sdr.Read()) //if theres a record, return, meaning we cannot allow it
                    {
                        MessageBox.Show("Cannot delete record, the data you are trying to delete has a history on main transaction. Make it inactive instead");
                        sdr.Close();
                        return;
                    }
                    else //we can change or update it
                    {
                        sdr.Close();*/
                        string query = "DELETE FROM TB_Users WHERE User_ID = @id";
                        SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                        cmd.Parameters.AddWithValue("@id", txt_User_ID.Text.Trim());
                        cmd.ExecuteNonQuery();
                        loadgrid();
                        enabledNewTransbutton();
                        clearControls();
                        MessageBox.Show("Record deleted successfully");
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


        private string SHA512(string Pass_word)
        {

            System.Security.Cryptography.SHA512Managed SHA5122 = new System.Security.Cryptography.SHA512Managed();
            byte[] Hash = System.Text.Encoding.UTF8.GetBytes(Pass_word);
            Hash = SHA5122.ComputeHash(Hash);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in Hash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        private void btn_SAVE1_Click(object sender, RoutedEventArgs e)
        {

            string psw = SHA512(txt_Password.Password);
            string usr = SHA512(txt_User_Name.Text);
            if (txt_Password.Password != txt_Password2.Password)
            {
                MessageBox.Show("كلمة المرور غير متطابقة");
                return;
            }
            if (txt_User_Name.Text.Trim() == "" || txt_Username_login.Text.Trim() == "" || txt_Password.Password == "" || txt_Password2.Password == "")
            {
                MessageBox.Show("يجب ملئ الحقول الفارغة");
                return;
            }


            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                //let's check first if the data trying to change is already exist.
                string check = "SELECT TOP 1 * FROM TB_Users WHERE User_id = @User_id";
                SqlCommand cmdcheck = new SqlCommand(check, dbcon.Con);
                cmdcheck.Parameters.AddWithValue("@User_id", txt_User_ID.Text.Trim());
                SqlDataReader sdr = cmdcheck.ExecuteReader();

                if (sdr.Read()) //if theres a record, return, meaning we cannot allow it
                {
                    MessageBox.Show("Cannot add this record, the data you are trying to insert already exist.");
                    sdr.Close();
                    return;
                }
                else //we can add or insert it
                {
                    sdr.Close();
                    SqlCommand cmd = new SqlCommand(" insert into TB_Users Values(@User_id,@User_name,@User_login,@Pass_word) " +
                                                 "  insert into TB_Priv (Priv_screen_ID,Priv_User_ID) select Screen_ID,@User_id  from TB_screens", dbcon.Con);
                    cmd.Parameters.AddWithValue("@User_id", txt_User_ID.Text.Trim());
                    cmd.Parameters.AddWithValue("@User_name", txt_User_Name.Text.Trim());
                    cmd.Parameters.AddWithValue("@User_login", usr);
                    cmd.Parameters.AddWithValue("@Pass_word", psw);
                    cmd.ExecuteNonQuery();
                    loadgrid();
                    enabledNewTransbutton();
                    clearControls();
                    //con = new SqlConnection();
                    dbcon.conclose();
                    btn_can_Click(sender, e);
                    MessageBox.Show("تم الحفظ");

                }
            }
        }
    }
}






