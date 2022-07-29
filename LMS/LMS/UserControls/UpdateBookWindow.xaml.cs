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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using LMS.BL;
using LMS.DAL;

namespace LMS
{
    /// <summary>
    /// Interaction logic for UpdateBookWindow.xaml
    /// </summary>
    public partial class UpdateBookWindow : Window
    {
        Class_book _Book = new Class_book();
        bool _check;
        DAL.DbConnection dbcon = new DAL.DbConnection();
        public UpdateBookWindow(bool check)
        {
            InitializeComponent();
          //  loadcombobox_bookstate();
            InitializeComponent();
            loadcombobox_catogray();
            loadcombobox_type();
            loadcombobox_author();
            loadcombobox_examiner();
            loadcombobox_translator();
            loadcombobox_language();
            loadcombobox_publisher();

            if (check == true)
            {
                _check = true;
                DataTable dt = _Book.usp_GetBookByID(UserControlBookManagement.ID);
                foreach (DataRow dr in dt.Rows)
                {
                    //book_id,book_num,book_name,dirctory_num,part_num,lcat_num,type_id,author_id,translator_id,producing_num,producing_date,copies_num,book_state
                    //,examiner_id,language_id,publisher_id,room_num,floor_num,wheel_num,shelf_num,discription)
                    txt_book_id.Text = dr["book_id"].ToString();
                    txt_book_name.Text = dr["book_name"].ToString();
                    txt_book_dir.Text = dr["dirctory_num"].ToString();
                    comb_catogray.Text = dr["cat_name"].ToString();
                    comb_type.Text = dr["type_name"].ToString();
                    comb_author.Text = dr["author_name"].ToString();
                    comb_translator.Text = dr["translator_name"].ToString();
                    comb_examiner.Text = dr["examiner_name"].ToString();
                    comb_language.Text = dr["language_name"].ToString();
                    comb_publisher.Text = dr["publisher_name"].ToString();
                    txt_room.Text = dr["room_num"].ToString();
                    txt_floor.Text = dr["floor_num"].ToString();
                    txt_wheel.Text = dr["wheel_num"].ToString();
                    txt_shelf.Text = dr["shelf_num"].ToString();
                    txt_description.Text = dr["discription"].ToString();



                }
            }
           


        }

        /* private void Readonly(bool state)
         {
             txt_book_id.IsReadOnly  = state;
         }*/





       /* private void loadcombobox_bookstate()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * FROM tbl_state";
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "tbl_state");
                txt_book_state.ItemsSource = dt.Tables[0].DefaultView;
                txt_book_state.DisplayMemberPath = dt.Tables[0].Columns["state_name"].ToString();
                txt_book_state.SelectedValuePath = dt.Tables[0].Columns["state_id"].ToString();

            }
            else
            {
                return;
            }
            dbcon.conclose();

        }*/


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

       

        private void btnUpdatebook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //let's check first if the textboxes are empty since we cannot allow a blank data
                if (txt_book_id.Text.Trim() == "" ||  txt_book_name.Text.Trim() == "" || comb_catogray.Text == "" || comb_type.Text == "" || comb_author.Text == "" || comb_language.Text == "")
                {
                    MessageBox.Show("يجب ملئ الحقول الإجبارية");
                    return;
                }
              /*  if (Convert.ToInt32(txt_copiesnum.Text) <= 0)
                {
                    MessageBox.Show("يجب الا يكون عدد النسخ اصغر من او يساوي الصفر");
                    return;
                }*/


                dbcon.conOpen();
                if (dbcon != null)
                {
                    //تعديل الكتاب


                    _Book.UPDATE_Book(Convert.ToInt32(txt_book_id.Text), txt_book_name.Text.Trim(), txt_book_dir.Text.Trim()
                   , Convert.ToInt32(comb_catogray.SelectedValue), Convert.ToInt32(comb_type.SelectedValue), Convert.ToInt32(comb_author.SelectedValue), Convert.ToInt32(comb_translator.SelectedValue),
                    Convert.ToInt32(comb_examiner.SelectedValue), Convert.ToInt32(comb_language.SelectedValue), Convert.ToInt32(comb_publisher.SelectedValue), txt_room.Text.Trim(), txt_floor.Text.Trim(), txt_wheel.Text.Trim(),
                    txt_shelf.Text.Trim(), txt_description.Text.Trim());
                    clearcontrols();
                    MessageBox.Show("تم التعديل  بنجاح");










                }
                else
                {
                    return;
                }
                dbcon.conclose();
            }
            catch (Exception ) { }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
