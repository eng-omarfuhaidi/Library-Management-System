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
using System.Data.SqlClient;
using System.Windows.Shapes;
using System.Data;
using LMS.DAL;
using LMS.BL;
namespace LMS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public TextBlock txt_FullName = new TextBlock();

        public static String user_n;
        public static String pass;
        DbConnection DBcon = new DbConnection();
        Class_User cl = new Class_User();
       
        public Login()
        {
            InitializeComponent();
            Keyboard.Focus(txt_Username);
          

        }



        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string psw = SHA512(txt_password.Password);
            string usr = SHA512(txt_Username.Text);
            DBcon.conOpen();
            SqlConnection cn = new SqlConnection(@"Data Source= .\SQLEXPRESS; Initial Catalog= Lib_Sys; Integrated Security = True;");

          
            try
            {
                SqlCommand cmd = new SqlCommand(" select * from TB_Users where User_name_login=@User_name and Pass_word=@psw ", DBcon.Con);

                cmd.Parameters.Add(new SqlParameter("@User_name", SqlDbType.VarChar)).Value = usr;
                cmd.Parameters.Add(new SqlParameter("@psw", SqlDbType.VarChar)).Value = psw;


                SqlDataReader Ra = cmd.ExecuteReader();
                Ra.Read();
                if (Ra.HasRows)
                {

                   
                    DataTable dt = cl.GetUserName(usr, psw);
                    foreach (DataRow dr in dt.Rows)
                    {
                        UserControlAddBorrowing ub = new UserControlAddBorrowing();
                        MainWindow main = new MainWindow();

                        int id = 1;
                        cl.username = dr["User_name"].ToString();
                        ub.txt_borrowingnumber.Text = dr["User_name"].ToString();
                        main.txt_username.Text = cl.username;
                       cl.Delet_libclreck(id);
                       cl.Set_libclerck(dr["User_name"].ToString());
                        main.Show();
                        this.Close();

                    }

                }
                else
                    MessageBox.Show(" Not Login ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBcon.conclose();

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void txt_Username_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

        }

        private void txt_Username_GotFocus(object sender, RoutedEventArgs e)
        {

        }

    
    }

      
    }
    