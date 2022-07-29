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
using LMS.BL;
using LMS.DAL;
using System.IO;

namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControlAddBook.xaml
    /// </summary>
    public partial class UserControlAddBook : UserControl
    {
        MainWindow main = new MainWindow();
        Class_book _Book = new Class_book();
        string strName, imageName;

        LMS.DAL.DbConnection dbcon = new LMS.DAL.DbConnection();
        public UserControlAddBook()
        {
            InitializeComponent();
            loadcombobox_catogray();
            loadcombobox_type();
            loadcombobox_author();
            loadcombobox_examiner();
            loadcombobox_translator();
            loadcombobox_language();
            loadcombobox_publisher();

        }

        private void loadcombobox_catogray()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * FROM tblcatogray";
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "tblcatogray");
                comb_catogray.ItemsSource = dt.Tables[0].DefaultView;
                comb_catogray.DisplayMemberPath = dt.Tables[0].Columns["cat_name"].ToString();
                comb_catogray.SelectedValuePath = dt.Tables[0].Columns["lcat_num"].ToString();

            }
            else
            {
                return;
            }
            dbcon.conclose();

        }

        private void loadcombobox_type()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * FROM tbltype";
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "tbltype");
                comb_type.ItemsSource = dt.Tables[0].DefaultView;
                comb_type.DisplayMemberPath = dt.Tables[0].Columns["type_name"].ToString();
                comb_type.SelectedValuePath = dt.Tables[0].Columns["type_id"].ToString();

            }
            else
            {
                return;
            }
            dbcon.conclose();

        }

        private void loadcombobox_author()
        {

            dbcon.conOpen();

            if (dbcon.Con != null)
            {
                string q = "SELECT * FROM tblauthor";
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "tblauthor");
                comb_author.ItemsSource = dt.Tables[0].DefaultView;
                comb_author.DisplayMemberPath = dt.Tables[0].Columns["author_name"].ToString();
                comb_author.SelectedValuePath = dt.Tables[0].Columns["author_id"].ToString();

            }
            else
            {
                return;
            }
            dbcon.conclose();

        }

        private void loadcombobox_translator()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * FROM tbltranslator";
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "tbltranslator");
                comb_translator.ItemsSource = dt.Tables[0].DefaultView;
                comb_translator.DisplayMemberPath = dt.Tables[0].Columns["translator_name"].ToString();
                comb_translator.SelectedValuePath = dt.Tables[0].Columns["translator_id"].ToString();

            }
            else
            {
                return;
            }
            dbcon.conclose();

        }

        private void loadcombobox_examiner()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * FROM tblexaminer";
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "tblexaminer");
                comb_examiner.ItemsSource = dt.Tables[0].DefaultView;
                comb_examiner.DisplayMemberPath = dt.Tables[0].Columns["examiner_name"].ToString();
                comb_examiner.SelectedValuePath = dt.Tables[0].Columns["examiner_id"].ToString();

            }
            else
            {
                return;
            }
            dbcon.conclose();

        }


        private void loadcombobox_language()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * FROM tbllanguage";
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "tbllanguage");
                comb_language.ItemsSource = dt.Tables[0].DefaultView;
                comb_language.DisplayMemberPath = dt.Tables[0].Columns["language_name"].ToString();
                comb_language.SelectedValuePath = dt.Tables[0].Columns["language_id"].ToString();

            }
            else
            {
                return;
            }
            dbcon.conclose();

        }





        private void loadcombobox_publisher()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * FROM tblpublisher";
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "tblpublisher");
                comb_publisher.ItemsSource = dt.Tables[0].DefaultView;
                comb_publisher.DisplayMemberPath = dt.Tables[0].Columns["publisher_name"].ToString();
                comb_publisher.SelectedValuePath = dt.Tables[0].Columns["publisher_id"].ToString();

            }
            else
            {
                return;
            }
            dbcon.conclose();

        }

       


        public void clearcontrols()
        {
            txt_book_id.Text = "";
         
            txt_book_name.Text = "";

            txt_book_dir.Text = "";
         
            comb_catogray.Text = "";
            comb_type.Text = "";
            comb_author.Text = "";
            comb_translator.Text = "";
          
         
          
           
            comb_examiner.Text = "";
            comb_language.Text = "";
            comb_publisher.Text = "";
            txt_room.Text = "";
            txt_floor.Text = "";
            txt_wheel.Text = "";
            txt_shelf.Text = "";
            txt_description.Text = "";
        }

        private void btn_addbook_Click(object sender, RoutedEventArgs e)
        {

            clearcontrols();
            // enabledNewTransbutton();
            btn_savebook.IsEnabled = true;
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (book_id)+1,1) from tblbook", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_book_id.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
        }

        private void btn_savebook_Click_1(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    //let's check first if the textboxes are empty since we cannot allow a blank data
                    if (txt_book_id.Text.Trim() == "" || txt_book_name.Text.Trim() == "" || comb_catogray.Text == "" || comb_type.Text == "" || comb_author.Text == "" || comb_language.Text == "")
                    {
                        MessageBox.Show("يجب ملئ الحقول الإجبارية");
                        return;
                    }
                    


                    dbcon.conOpen();
                    if (dbcon != null)
                    {
                        //let's check first if the data trying to change is already exist.
                        string check = "SELECT TOP 1 * FROM tblBook WHERE book_name = @book_name";
                        SqlCommand cmdcheck = new SqlCommand(check, dbcon.Con);
                        cmdcheck.Parameters.AddWithValue("@book_name", txt_book_name.Text.Trim());
                        SqlDataReader sdr = cmdcheck.ExecuteReader();

                        if (sdr.Read()) //if theres a record, return, meaning we cannot allow it
                        {
                            MessageBox.Show("هناك كتاب موجود بهذا الإسم");
                            sdr.Close();
                            return;

                        }
                        else //we can add or insert it
                        {

                            byte[] Picture;

                            FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

                            //Initialize a byte array with size of stream
                            Picture = new byte[fs.Length];

                            //Read data from the file stream and put into the byte array
                            fs.Read(Picture, 0, Convert.ToInt32(fs.Length));

                            //Close a file stream
                            fs.Close();
                            _Book.Add_book(Convert.ToInt32(txt_book_id.Text), txt_book_name.Text, txt_book_dir.Text, Convert.ToInt32(comb_catogray.SelectedValue), Convert.ToInt32(comb_type.SelectedValue), Convert.ToInt32(comb_author.SelectedValue), Convert.ToInt32(comb_translator.SelectedValue),
                                Convert.ToInt32(comb_examiner.SelectedValue),Convert.ToInt32(comb_language.SelectedValue), Convert.ToInt32(comb_publisher.SelectedValue), txt_room.Text, txt_floor.Text,
                                txt_wheel.Text, txt_shelf.Text, txt_description.Text, Picture);
                           
                            clearcontrols();
                            MessageBox.Show("تمت الإضافة بنجاح");

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
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            main.Close ();
        }

        private void txt_book_name_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

        }

        private void btn_addimage_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Microsoft.Win32.FileDialog fldlg = new Microsoft.Win32.OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    strName = fldlg.SafeFileName;
                    imageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    book_imag.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }



}

