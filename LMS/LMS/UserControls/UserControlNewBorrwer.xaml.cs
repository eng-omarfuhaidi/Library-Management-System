using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Data;
using System.Data.SqlClient;
using LMS.DAL;
using LMS.BL;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using System.IO;

namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControlNewBorroer.xaml
    /// </summary>
    public partial class UserControlNewBorroer : System.Windows.Controls.UserControl
    {
        string strName, imageName;
        DbConnection dbcon = new DbConnection();
        ClassBorrower clab = new ClassBorrower();
        public UserControlNewBorroer()
        {
            InitializeComponent();
            loadcombobox_borrtype();

            dg_borrower.ItemsSource = clab.GET_ALLBorrowers().DefaultView;


        }

        private void loadcombobox_borrtype()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * FROM tblborrowertype";
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "tblborrowertype");
                comb_borrtype.ItemsSource = dt.Tables[0].DefaultView;
                comb_borrtype.DisplayMemberPath = dt.Tables[0].Columns["borrowertype_name"].ToString();
                comb_borrtype.SelectedValuePath = dt.Tables[0].Columns["borrowertype_id"].ToString();

            }
            else
            {
                return;
            }
            dbcon.conclose();

        }





        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        public void clearcontrols()
        {
            txt_borrid.Text = "";
            txt_borrname.Text = "";

            txt_borrphone.Text = "";
            txt_borremail.Text = "";
            txt_borrusername.Text = "";
            pass_borrpassword.Password = "";
            Pass_passverfiey.Password = "";
            comb_borrtype.Text = "";
            txt_clerkname.Text = "";


        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txt_search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_search.Text == "")
            {
                txt_block.Visibility = Visibility.Visible;
            }
        }

        private void txt_search_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_block.Visibility = Visibility.Collapsed;
        }

        private void btn_newborrower_Click(object sender, RoutedEventArgs e)
        {

            clearcontrols();
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (borrow_id)+1,1) from tblborrower", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_borrid.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
            btn_saveborrower.IsEnabled = true;

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            // borr_image.Source = "DAL\guest.png";


        }


        private void btn_saveborrower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pass_borrpassword.Password != Pass_passverfiey.Password)
                {
                    MessageBox.Show("كلمة المرور غير متطابقة");
                    return;
                }
                if (txt_borrname.Text.Trim() == null || txt_borrphone.Text.Trim() == null)
                {
                    MessageBox.Show("يجب ملئ الحقول الفارغة");
                    return;
                }
                byte[] Picture;
                if (imageName == "")
                {
                    Picture = new byte[0];
                    clab.Add_Borrower(Convert.ToInt32(txt_borrid.Text), txt_borrname.Text, txt_borrphone.Text, txt_borremail.Text, txt_borrusername.Text,
                        pass_borrpassword.Password, Convert.ToInt32(comb_borrtype.SelectedValue), txt_clerkname.Text, Picture, Convert.ToInt32(txt_allowable), "without_image");
                    System.Windows.Forms.MessageBox.Show("تمت الإضافة بنجاح", "الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dg_borrower.ItemsSource = clab.GET_ALLBorrowers().DefaultView;
                }
                else
                {
                    FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

                    //Initialize a byte array with size of stream
                    Picture = new byte[fs.Length];

                    //Read data from the file stream and put into the byte array
                    fs.Read(Picture, 0, Convert.ToInt32(fs.Length));

                    //Close a file stream
                    fs.Close();

                    // MemoryStream ms = new MemoryStream();
                    //  Picture.source.(ms, pbox.Image.RawFormat);
                    // Picture = ms.ToArray();
                    clab.Add_Borrower(Convert.ToInt32(txt_borrid.Text), txt_borrname.Text, txt_borrphone.Text, txt_borremail.Text, txt_borrusername.Text,
                        pass_borrpassword.Password, Convert.ToInt32(comb_borrtype.SelectedValue), txt_clerkname.Text, Picture, Convert.ToInt32(txt_allowable.Text), "with_image");
                    System.Windows.Forms.MessageBox.Show("تمت الإضافة بنجاح", "الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dg_borrower.ItemsSource = clab.GET_ALLBorrowers().DefaultView;
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            /*
                        dbcon.conOpen();
                        if (dbcon.Con != null)
                        {
                            string query = "UPDATE tblborrower SET laters = @laters  WHERE borrow_id = @borrow_id";
                            SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                            // bool state = false;
                            cmd.Parameters.AddWithValue("@laters", false);
                            cmd.Parameters.AddWithValue("@borrow_id", txt_borrid.Text);
                            cmd.ExecuteNonQuery();
                        }
                        dbcon.conclose();
                        */
        }

        private void btnget_imag_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
                    borr_image.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void dg_borrower_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comb_borrtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToInt32(comb_borrtype.SelectedValue) == 1 | Convert.ToInt32(comb_borrtype.SelectedValue) == 2)
            {
                if (Convert.ToInt32(comb_borrtype.SelectedValue) == 1)
                {



                    this.lab_clerck.Content = "الكلية";
                }
                else
                {

                    this.lab_clerck.Content = "المسمى الوظيفي";
                }
            }
            else
            {

                this.lab_clerck.Content = "الدرجة العلمية";


            }
        }

        private void btnget_card_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
                    card_image.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pass_borrpassword.Password != Pass_passverfiey.Password)
                {
                    MessageBox.Show("كلمة المرور غير متطابقة");
                    return;
                }
                if (txt_borrname.Text.Trim() == null || txt_borrphone.Text.Trim() == null)
                {
                    MessageBox.Show("يجب ملئ الحقول الفارغة");
                    return;
                }
                byte[] Picture;

                FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

                //Initialize a byte array with size of stream
                Picture = new byte[fs.Length];

                //Read data from the file stream and put into the byte array
                fs.Read(Picture, 0, Convert.ToInt32(fs.Length));

                //Close a file stream
                fs.Close();
                clab.UPDATE_borowe(Convert.ToInt32(txt_borrid.Text), txt_borrname.Text, txt_borrphone.Text, txt_borremail.Text, txt_borrusername.Text,
                       pass_borrpassword.Password, Convert.ToInt32(comb_borrtype.SelectedValue), txt_clerkname.Text, Picture, Convert.ToInt32(txt_allowable.Text));
                System.Windows.Forms.MessageBox.Show("تم التعديل بنجاح", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dg_borrower.ItemsSource = clab.GET_ALLBorrowers().DefaultView;





















            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);




            }
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            _ = new DataTable();
            DataTable Dt = clab.Searchborrower_information(txt_search.Text);
            dg_borrower.ItemsSource = Dt.DefaultView;
        }

        

        private void dg_borrower_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (dg_borrower.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_borrower.SelectedItems[0];
                TextBlock txt = new TextBlock();
                txt_borrid.Text = x[0].ToString();
                txt_borrname.Text = x[1].ToString();
                txt_borrphone.Text = x[2].ToString();
                txt_borremail.Text = x[3].ToString();
                txt_borrusername.Text = x[4].ToString();
                pass_borrpassword.Password = x[5].ToString();
                comb_borrtype.Text = x[6].ToString();
                txt_clerkname.Text = x[7].ToString();
                txt_allowable.Text = x[8].ToString();

            }

           

        }
    } 
}