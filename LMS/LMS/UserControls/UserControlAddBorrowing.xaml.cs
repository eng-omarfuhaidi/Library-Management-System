using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LMS.BL;
using LMS.DAL;
using System.Data.SqlClient;
using System.Windows.Controls.Primitives;
using DataGridCell = System.Windows.Controls.DataGridCell;
using MessageBox = System.Windows.MessageBox;
using static System.Net.Mime.MediaTypeNames;
using TextBox = System.Windows.Controls.TextBox;
using GroupBox = System.Windows.Controls.GroupBox;

namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControlAddBorrowing.xaml
    /// </summary>
    public partial class UserControlAddBorrowing : System.Windows.Controls.UserControl
    {
        Class_User cl = new Class_User();
        Login lg = new Login();
        Class_copy cc = new Class_copy();
        Class_book classb = new Class_book();
        DbConnection dbcon = new DbConnection();
        ClassBorrower clab = new ClassBorrower();
        string[] collections;
        public static string image;
        DataTable Dt = new DataTable();
        MainLoan ml = new MainLoan();

        TextBlock txt1 = new TextBlock();
        TextBlock txt2 = new TextBlock();
        TextBlock txt3 = new TextBlock();
        TextBlock txt4 = new TextBlock();
        TextBlock txt5 = new TextBlock();

        public string user;

        public UserControlAddBorrowing()
        {
            InitializeComponent();
            date_borrowingdate.SelectedDate = DateTime.Now;
            disablecontrolos();
            fillClerck_name();
          // fillClerck_name();
            LoadData();
            CreateDataTable();
            Loadlistbook();
            //Loadlistauthor();
            //   txt_authornamesearching.Visibility=Visibility.Collapsed;
            dg_copylist.Visibility = Visibility.Collapsed;
            list1.Visibility = Visibility.Collapsed;
            listbooks_.Visibility = Visibility.Collapsed;
            //  listauthors.Visibility = Visibility.Collapsed;
            dg_copylist.ItemsSource = classb.GET_ALL_books().DefaultView;
            collections = new string[] { "William James", "Robin Hood", "David Copperfield", "Albert Einstein",
                             "Me", "You", "Richard D. Feynman", "David Beckham", "Fermi", "Someone somewhere"};

        }

        void LoadData()
        {

            try
            {
                dbcon.conOpen();
                DataTable Dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter("select *from tblborrower", dbcon.Con);
                Da.Fill(Dt);
                list1.DataContext = Dt;
                list1.DisplayMemberPath = "borrower_name";
                list1.SelectedValuePath = "borrow_id";
                /*  DataRowView x = (DataRowView)list1.SelectedItems[0];
                  txt_borrowernumber.Text = Dt.Rows[0]["borrow_id"].ToString();
                  txt_borrowername.Text = Dt.Rows[0]["borrower_name"].ToString();
                  txt_phone.Text = Dt.Rows[0][3].ToString();
                  txt_email.Text = Dt.Rows[0][4].ToString();*/
            }
            catch (Exception)
            {

                // throw;
            }
            dbcon.conclose();

        }

        public void disablecontrolos()
        {
            txt_borrowernumber.IsEnabled = false;
            txt_borrowername.IsEnabled = false;
            txt_phone.IsEnabled = false;
            txt_email.IsEnabled = false;
            txt_BorrDisc.IsEnabled = false;
            txt_borrowingnumber.IsEnabled = false;
            txt_LibClerck.IsEnabled = false;
            txt_booknamesearching.IsEnabled = false;
            txt_bornmae.IsEnabled = false;

        }


        public void enablecontrols()
        {
            txt_borrowernumber.IsEnabled = true;
            txt_borrowername.IsEnabled = true;
            txt_phone.IsEnabled = true;
            txt_email.IsEnabled = true;
            txt_BorrDisc.IsEnabled = true;
            txt_borrowingnumber.IsEnabled = true;
            txt_LibClerck.IsEnabled = true;
            txt_booknamesearching.IsEnabled = true;
            txt_bornmae.IsEnabled = true;

        }


        private void list1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list1.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)list1.SelectedItems[0];
                txt_bornmae.Text = x[0].ToString();



                DataTable dt = clab.GetBoroweresByName(txt_bornmae.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    txt3.Text = dr["borrow_id"].ToString();
                }
                dbcon.conOpen();
                if (dbcon.Con != null)
                {
                    /* SqlCommand cmdn = new SqlCommand("select later_status from tblloan WHERE borrowed_id =@borrow_id", dbcon.Con);
                     cmdn.Parameters.AddWithValue("@borrow_id", txt3.Text);
                     SqlDataReader Ra = cmdn.ExecuteReader();
                     Ra.Read();*/

                    SqlCommand cmdn = new SqlCommand("select Count(*) from tblloan WHERE borrowed_id =@borrow_id", dbcon.Con);
                    cmdn.Parameters.AddWithValue("@borrow_id", txt3.Text);
                    // int count = (int)cmdn.ExecuteScalar();
                    //  if (count > 0)
                    // {
                    SqlDataReader Ra = cmdn.ExecuteReader();
                    Ra.Read();
                    if (Ra.HasRows)
                    {
                        txt4.Text = Ra[0].ToString();
                        Ra.Close();
                        if (Convert.ToInt32(txt4.Text) > 0)
                        {


                            MessageBox.Show(txt4.Text);
                            SqlCommand cmdh = new SqlCommand("select later_status from tblloan WHERE borrowed_id =@borrow_id", dbcon.Con);
                            cmdh.Parameters.AddWithValue("@borrow_id", txt3.Text);
                            SqlDataReader Rh = cmdh.ExecuteReader();
                            Rh.Read();
                            if (Convert.ToBoolean(Rh[0].ToString()) == true)
                            {
                                Rh.Close();

                                txt_bornmae.Text = "";
                                list1.Visibility = Visibility.Collapsed;
                                System.Windows.Forms.MessageBox.Show("هذا الشخص عليه متآخرات ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }



                            else
                            {
                                Rh.Close();

                                foreach (DataRow dn in dt.Rows)
                                {
                                    txt_borrowernumber.Text = dn["borrow_id"].ToString();
                                    txt_borrowername.Text = dn["borrower_name"].ToString();
                                    txt_phone.Text = dn["tel"].ToString();
                                    txt_email.Text = dn["email"].ToString();

                                }
                                txt_bornmae.Text = "";

                                SqlCommand cmdg = new SqlCommand("select allowable from tblborrower WHERE borrow_id =@borrow_id", dbcon.Con);
                                cmdg.Parameters.AddWithValue("@borrow_id", txt3.Text);
                                SqlDataReader Rc = cmdg.ExecuteReader();

                                Rc.Read();
                                txt_period.Text = Rc[0].ToString();
                                date_return.SelectedDate = DateTime.Today.AddDays(Convert.ToDouble(Rc[0].ToString()));

                                Rc.Close();
                            }
                        }




                        else
                        {
                            Ra.Close();

                            foreach (DataRow dn in dt.Rows)
                            {
                                txt_borrowernumber.Text = dn["borrow_id"].ToString();
                                txt_borrowername.Text = dn["borrower_name"].ToString();
                                txt_phone.Text = dn["tel"].ToString();
                                txt_email.Text = dn["email"].ToString();

                            }
                            txt_bornmae.Text = "";

                            SqlCommand cmd1 = new SqlCommand("select allowable from tblborrower WHERE borrow_id =@borrow_id", dbcon.Con);
                            cmd1.Parameters.AddWithValue("@borrow_id", txt3.Text);
                            SqlDataReader R12 = cmd1.ExecuteReader();

                            R12.Read();
                            txt_period.Text = R12[0].ToString();
                            date_return.SelectedDate = DateTime.Today.AddDays(Convert.ToDouble(R12[0].ToString()));

                            R12.Close();
                        }
                    }
                }
                dbcon.conclose();
            }


            list1.Visibility = Visibility.Collapsed;
        }






        private void txt_bornmae_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataTable Dt = clab.Searchborrower_2(txt_bornmae.Text);
            list1.ItemsSource = Dt.DefaultView;
            list1.Visibility = Visibility.Visible;

        }




        private void txt_bornmae_GotFocus(object sender, RoutedEventArgs e)
        {

            list1.Visibility = Visibility.Visible;
        }

        private void txt_bornmae_LostFocus(object sender, RoutedEventArgs e)
        {
            if (list1.Visibility == Visibility.Visible)
            {
                list1.Visibility = Visibility.Collapsed;
            }
        }

        /* private void txt_booksearching_TextChanged(object sender, TextChangedEventArgs e)
         {

             DataTable dt = classb.Searchbook(txt_booksearching.Text);
             dg_booklist.ItemsSource = dt.DefaultView;
         }*/

        private void btn_choice_Click(object sender, RoutedEventArgs e)
        {
            dg_copylist.Visibility = Visibility.Visible;
            gd_bookbrorrowed.Visibility = Visibility.Collapsed;

        }



        void CreateDataTable()
        {
            Dt.Columns.Add("رقم النسخة");
            Dt.Columns.Add("اسم النسخة");

            Dt.Columns.Add("رقم الإصدار");








            gd_bookbrorrowed.ItemsSource = Dt.DefaultView;

            //Add ButtonColumn To DataGridView
            /* DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
              btn.HeaderText = "اختيار منتج";
              btn.Text = "البحث";
              btn.UseColumnTextForButtonValue = true;
              dgvProducts.Columns.Insert(0,btn); */
        }






        public DataGridCell GetCell(int row, int column)
        {
            DataGridRow rowContainer = GetRow(row);
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    gd_bookbrorrowed.ScrollIntoView(rowContainer, gd_bookbrorrowed.Columns[column]);
                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
        }
        public DataGridRow GetRow(int index)
        {
            DataGridRow row = (DataGridRow)gd_bookbrorrowed.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                gd_bookbrorrowed.UpdateLayout();
                gd_bookbrorrowed.ScrollIntoView(gd_bookbrorrowed.Items[index]);
                row = (DataGridRow)gd_bookbrorrowed.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }
        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T); int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }


        private void btn_deleting_Click(object sender, RoutedEventArgs e)
        {
            if (gd_bookbrorrowed.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)gd_bookbrorrowed.SelectedItem;
                Dt.Rows.Remove(row.Row);

            }
            else
            {
                return;
            }
            // gd_bookbrorrowed.ItemsSource = Dt.DefaultView;
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (gd_bookbrorrowed.SelectedIndex != -1)
            {

                DataRowView x = (DataRowView)gd_bookbrorrowed.SelectedItems[0];
                txt_copynumber.Text = x[0].ToString();
                txt_copyname.Text = x[1].ToString();

                txt_edition.Text = x[2].ToString();

                DataRowView row = (DataRowView)gd_bookbrorrowed.SelectedItem;

                Dt.Rows.Remove(row.Row);

            }
            else
            {
                return;
            }
        }

        private void clearControls()
        {
            txt_borrowingnumber.Text = "";
            txt_BorrDisc.Text = "";
            //  date_borrowingdate.Text = "";
            txt_borrowernumber.Text = "";
            txt_borrowername.Text = "";
            txt_phone.Text = "";
            txt_email.Text = "";
            txt_copynumber.Text = "";
            txt_copyname.Text = "";
            date_return.Text = "";
            txt_period.Text = "";
            txt_edition.Text = "";
        }
        private void btn_addborrowing_Click(object sender, RoutedEventArgs e)
        {

            clearControls();
            enablecontrols();
            dbcon.conOpen();
            SqlCommand cmd = new SqlCommand("select ISNULL (MAX (loan_id)+1,1) from tblloan", dbcon.Con);
            SqlDataReader Ra = cmd.ExecuteReader();
            Ra.Read();
            txt_borrowingnumber.Text = Ra[0].ToString();
            Ra.Close();
            dbcon.conclose();
        }

        private void btn_saveborrowing_Click(object sender, RoutedEventArgs e)
        {
            if (txt_borrowingnumber.Text.Trim() == null || date_borrowingdate.Text.Trim() == null || txt_borrowernumber.Text.Trim() == "" || txt_borrowername.Text.Trim() == "" || txt_phone.Text.Trim() == "" || txt_email.Text.Trim() == "")
            {
                MessageBox.Show("يجب ملئ الحقول الفارغة");
                return;
            }
            try
            {

                clab.add_loan(txt_borrowingnumber.Text, txt_BorrDisc.Text, date_borrowingdate.Text, txt_LibClerck.Text, Convert.ToInt32(txt_borrowernumber.Text), date_return.Text, Convert.ToInt32(txt_period.Text));

                for (int i = 0; i < gd_bookbrorrowed.Items.Count - 1; i++)
                {


                    DataGridCell cell2 = GetCell(i, 0);
                    TextBlock tb2 = cell2.Content as TextBlock;//copy_id

                    clab.add_loandetails(txt_borrowingnumber.Text, Convert.ToInt32(tb2.Text)
                       , Convert.ToInt32(txt1.Text));

                    dbcon.conOpen();
                    if (dbcon.Con != null)
                    {
                        string query = "UPDATE tblcopy SET status = @status  WHERE copy_id = @copy_id";
                        SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                        // bool state = false;
                        cmd.Parameters.AddWithValue("@status", true);
                        cmd.Parameters.AddWithValue("@copy_id", tb2.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                    dbcon.conclose();

                    dbcon.conOpen();
                    if (dbcon.Con != null)
                    {

                        SqlCommand cmdn = new SqlCommand("select avaliablecopies_num from tblbook WHERE book_id=@book_id", dbcon.Con);
                        cmdn.Parameters.AddWithValue("@book_id", txt1.Text);
                        SqlDataReader Ra = cmdn.ExecuteReader();
                        Ra.Read();

                        txt2.Text = Ra[0].ToString();
                        Ra.Close();

                    }
                    dbcon.conclose();
                    dbcon.conOpen();
                    if (dbcon.Con != null)
                    {
                        string query = "UPDATE tblbook SET avaliablecopies_num= @avaliablecopies_num  WHERE book_id = @book_id";
                        SqlCommand cmd = new SqlCommand(query, dbcon.Con);
                        cmd.Parameters.AddWithValue("@avaliablecopies_num", Convert.ToInt32(txt2.Text) - 1);
                        cmd.Parameters.AddWithValue("@book_id", txt1.Text);
                        cmd.ExecuteNonQuery();
                    }
                    dbcon.conclose();

                    //dg_copylist.ItemsSource = classb.GET_ALL_books().DefaultView;

                    System.Windows.Forms.MessageBox.Show("تمت الإضافة بنجاح", "الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gd_bookbrorrowed.ItemsSource = null;
                }
            }

            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }





            clearControls();
        }

        private void txt_booknamesearching_TextChanged(object sender, TextChangedEventArgs e)
        {


            DataTable Dt = cc.Searhbookname(txt_booknamesearching.Text);
            listbooks_.ItemsSource = Dt.DefaultView;
            listbooks_.Visibility = Visibility.Visible;
        }

        private void txt_booknamesearching_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_block.Visibility = Visibility.Collapsed;
            //listbooks_.Visibility = Visibility.Visible;

        }



        void Loadlistbook()
        {

            try
            {
                dbcon.conOpen();

                /* string q = "SELECT * FROM tblbook";
                    SqlCommand cmd = new SqlCommand(q, dbcon.Con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    sda.Fill(dt, "tblbook");
                  listbooks_.ItemsSource = dt.Tables[0].DefaultView;
                    listbooks_.DisplayMemberPath = dt.Tables[0].Columns["book_name"].ToString();
                    listbooks_.SelectedValuePath = dt.Tables[0].Columns["book_id"].ToString();*/




                DataTable Dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter("select *from tblbook", dbcon.Con);
                Da.Fill(Dt);
                listbooks_.DataContext = Dt;
                listbooks_.DisplayMemberPath = "book_name";
                listbooks_.SelectedValuePath = "book_id";
                /*  DataRowView x = (DataRowView)listbooks_.SelectedItems[0];
                  txt_borrowernumber.Text = Dt.Rows[0]["borrow_id"].ToString();
                  txt_borrowername.Text = Dt.Rows[0]["borrower_name"].ToString();
                  txt_phone.Text = Dt.Rows[0][3].ToString();
                  txt_email.Text = Dt.Rows[0][4].ToString();*/
            }
            catch (Exception)
            {

                // throw;
            }
            dbcon.conclose();


        }






        private void txt_booknamesearching_LostFocus(object sender, RoutedEventArgs e)
        {
            txt_block.Visibility = Visibility.Visible;
            if (listbooks_.Visibility == Visibility.Visible)
            {
                listbooks_.Visibility = Visibility.Collapsed;

            }
        }



        private void listbooks__SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbooks_.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)listbooks_.SelectedItems[0];
                TextBlock txt = new TextBlock();
                txt.Text = x[0].ToString();
                dbcon.conOpen();
                if (dbcon.Con != null)
                {

                    SqlCommand cmdn = new SqlCommand("select book_id  from tblbook WHERE book_name=@book_name", dbcon.Con);
                    cmdn.Parameters.AddWithValue("@book_name", txt.Text);
                    SqlDataReader Ra = cmdn.ExecuteReader();
                    Ra.Read();


                    txt1.Text = Ra[0].ToString();
                    DataTable dt = cc.GetcopyByID(Convert.ToInt32(txt1.Text));
                    dg_copylist.ItemsSource = dt.DefaultView;
                    dg_copylist.Visibility = Visibility.Visible;

                    Ra.Close();

                }
                txt_booknamesearching.Text = "";
                this.listbooks_.Visibility = Visibility.Collapsed;


                dbcon.conclose();

                // txt_booknamesearching.Text =listbooks_.DisplayMemberPath;
                // listbooks_.Visibility = Visibility.Collapsed;
            }

        }

        private void txt_edition_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {


                for (int i = 0; i < gd_bookbrorrowed.Items.Count; i++)
                {
                    for (int j = 0; j < gd_bookbrorrowed.Columns.Count; j++)
                    {           //loop throught cell
                        DataGridCell cell = GetCell(i, 0);
                        TextBlock tb = cell.Content as TextBlock;
                        if (txt_copynumber.Text == tb.Text.ToString())
                        {
                            System.Windows.Forms.MessageBox.Show("هذا الكتاب تم حجزه مسبقاً ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        //  MessageBox.Show(tb.Text);
                    }
                }
                DataRow r = Dt.NewRow();
                r[0] = txt_copynumber.Text;
                r[1] = txt_copyname.Text;
                r[2] = txt_edition.Text;





                Dt.Rows.Add(r);


                gd_bookbrorrowed.ItemsSource = Dt.DefaultView;


                txt_copynumber.Text = "";
                txt_copyname.Text = "";
                txt_edition.Text = "";
            }
        }

        private void dg_copylist_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (dg_copylist.SelectedIndex != -1)
            {
                DataRowView x = (DataRowView)dg_copylist.SelectedItems[0];
                if (Convert.ToBoolean(x[6].ToString()) == true || Convert.ToBoolean(x[7].ToString()) == true)
                {
                    System.Windows.Forms.MessageBox.Show("لايمكنك استعارة هذه النسخة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                txt_copynumber.Text = x[0].ToString();
                txt_copyname.Text = x[1].ToString();
                txt_edition.Text = x[2].ToString();





            }

            else
            {

                return;
            }
            dg_copylist.Visibility = Visibility.Collapsed;
            gd_bookbrorrowed.Visibility = Visibility.Visible;

        }

        private void date_borrowingdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void gd_bookbrorrowed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_deleting.IsEnabled = true;
            btn_update.IsEnabled = true;
        }

        public void fillClerck_name()
        {
            dbcon.conOpen();
            if (dbcon.Con != null)
            {

                SqlCommand cmdn = new SqlCommand("select user_name  from user_names", dbcon.Con);
                SqlDataReader Ra = cmdn.ExecuteReader();
                Ra.Read();


              txt_LibClerck.Text = Ra[0].ToString();


                Ra.Close();
            }
        }
        
    }

    }


    
    
