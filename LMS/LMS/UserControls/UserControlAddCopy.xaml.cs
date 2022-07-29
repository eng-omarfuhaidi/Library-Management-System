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
using System.Data;
using System.Data.SqlClient;
using LMS.DAL;
using LMS.BL;
using System.Windows.Forms;

namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControlAddCopy.xaml
    /// </summary>
    public partial class UserControlAddCopy : System.Windows.Controls.UserControl
    {
        DbConnection dbcon = new DbConnection();
        Class_book class_B = new Class_book();
        Class_copy class_c = new Class_copy();
        TextBlock tx1 = new TextBlock();
        TextBlock tx2 = new TextBlock();
        public UserControlAddCopy()
        {
            InitializeComponent();
            loadcombobox_copystate();
            DataTable dt = new DataTable();
            dg_booklist.Visibility = Visibility.Collapsed;

            //  dt = class_Book.GET_ALL_books();
            dg_booklist.ItemsSource = class_B.GET_ALL_books().DefaultView;

        }
         private void loadcombobox_copystate()
        {

            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                string q = "SELECT * FROM tbl_state";
                SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt, "tbl_state");
                comb_copystate.ItemsSource = dt.Tables[0].DefaultView;
                comb_copystate.DisplayMemberPath = dt.Tables[0].Columns["state_name"].ToString();
                comb_copystate.SelectedValuePath = dt.Tables[0].Columns["state_id"].ToString();

            }
            else
            {
                return;
            }
            dbcon.conclose();

        }

        private void dg_booklist_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dg_booklist.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_booklist.SelectedItems[0];
                txt_booknum.Text = x[0].ToString();
                txt_bookname.Text = x[1].ToString();
                txt_bookauthor.Text = x[5].ToString();

            }
            dg_booklist.Visibility = Visibility.Collapsed;
        }

        private void btn_choice_Click(object sender, RoutedEventArgs e)
        {
            dg_booklist.Visibility = Visibility.Visible;
            dg_copylist.Visibility = Visibility.Collapsed;
        }

        private void dg_copylist_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_savecopy_Click(object sender, RoutedEventArgs e)
        {
            if (txt_booknum.Text.Trim() == "" || txt_localnumber.Text.Trim()=="")
            {
                System.Windows.MessageBox.Show("يجب ملئ الحقول الإجبارية");
                return;
            }
            dbcon.conOpen();
            if (dbcon.Con != null)
            {
                //let's check first if the data trying to change is already exist.
                string check = "SELECT TOP 1 * FROM tblcopy WHERE copy_id = @copy_id";
                SqlCommand cmdcheck = new SqlCommand(check, dbcon.Con);
                cmdcheck.Parameters.AddWithValue("@copy_id", txt_localnumber.Text.Trim());
                SqlDataReader sdr = cmdcheck.ExecuteReader();

                if (sdr.Read()) //if theres a record, return, meaning we cannot allow it
                {
                    System.Windows.MessageBox.Show("رقم النسخة المحلي مكرر");
                    sdr.Close();
                    return;
                }
            }
            dbcon.conclose();
            try
                {
                   
                    class_c.Add_copy(Convert.ToInt32(txt_localnumber.Text), Convert.ToInt32(txt_booknum.Text), txt_editin.Text, Convert.ToDateTime(date_edition.SelectedDate),
                        Convert.ToDateTime(date_copycomming.SelectedDate), Convert.ToInt32(comb_copystate.SelectedValue), txt_part.Text);

                /*جلب كمية الكتب الكلية والمتوفرة*/
                dbcon.conOpen();
                if (dbcon.Con != null)
                {

                    SqlCommand cmdn = new SqlCommand("select totalcopies_num ,avaliablecopies_num from tblbook WHERE book_id=@book_id", dbcon.Con);
                    cmdn.Parameters.AddWithValue("@book_id", txt_booknum.Text);
                    SqlDataReader Ra = cmdn.ExecuteReader();
                    Ra.Read();
                    
                    tx1.Text = Ra[0].ToString();
                    tx2.Text = Ra[1].ToString();
                    Ra.Close();

                }
                dbcon.conclose();
               dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    string query = "UPDATE tblbook SET totalcopies_num=@totalcopies_num ,avaliablecopies_num= @avaliablecopies_num  WHERE book_id = @book_id";
                    SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                    cmd.Parameters.AddWithValue("@totalcopies_num",Convert.ToInt32( tx1.Text)+1);
                    cmd.Parameters.AddWithValue("@avaliablecopies_num",Convert.ToInt32(tx2.Text)+1);
                    cmd.Parameters.AddWithValue("@book_id", txt_booknum.Text);
                    cmd.ExecuteNonQuery();
                }
                dbcon.conclose();

                System.Windows.Forms.MessageBox.Show("تمت الإضافة بنجاح", "الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch (Exception exe)
                {
                    System.Windows.MessageBox.Show(exe.Message);
                }
           

        }

        private void btn_newcopy_Click(object sender, RoutedEventArgs e)
        {
            btn_savecopy.IsEnabled = true;
        }
    }
}
