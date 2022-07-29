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
using LMS.DAL;
using LMS.BL;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControlBookManagement.xaml
    /// </summary>
    public partial class UserControlBookManagement : UserControl

    { DbConnection dbcon = new DbConnection();
        
        public static string ID;
        Class_book class_B = new Class_book();    
        public UserControlBookManagement()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
               
       //  dt = class_Book.GET_ALL_books();
            
                dt = class_B.GET_ALL_books();
            dg_books.ItemsSource = dt.DefaultView;
        }

      

        private void txt_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            

            DataTable Dt = new DataTable();
            Dt = class_B.Searchbook(txt_name.Text);
            dg_books.ItemsSource = Dt.DefaultView;
        }

        private void btn_dletebook_Click(object sender, RoutedEventArgs e)
        {
            if (dg_books.SelectedIndex != -1)
            {
                if (System.Windows.Forms.MessageBox.Show("هل تريد فعلا حذف الكتاب المحدد؟", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    DataRowView x = (DataRowView)dg_books.SelectedItems[0];
                    class_B.DeleteBook(x[0].ToString());
                    System.Windows.Forms.MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dg_books.ItemsSource = class_B.GET_ALL_books().DefaultView;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("تم إلغاء عملية الحذف", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("  حدد الصف الذي تريد حذفه    ", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_ubdate_Click(object sender, RoutedEventArgs e)
        {
            if (dg_books.SelectedIndex != -1)
            {
                /* try  {*/

                DataRowView x = (DataRowView)dg_books.SelectedItems[0];


                ID = x[0].ToString();
                new UpdateBookWindow(true).ShowDialog();
            }
              /*  UserControl ic;
                ic = new UserControlBookManagement();

                MainWindow mainWindow = new MainWindow();
                mainWindow.GridMain.Children.Add(ic);
                mainWindow.Show()*/


                    //throw;

            }

        private void txt_name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_name.Text == "")
            {
                txt_block.Visibility = Visibility.Visible;
            }
        }

        private void txt_name_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_block.Visibility = Visibility.Collapsed;
        }
        // catch (Exception exc) { }
        /* UserControlAddBooks uc = new UserControlAddBooks();
         uc.btn_addbook.Visibility = Visibility.Collapsed;
         uc.btn_savebook.Visibility =Visibility.Collapsed;
         uc.btn_updatebook.Visibility =Visibility.Visible;
         uc.btn_cancel_Copy.Visibility = Visibility.Collapsed;
         uc.comb_author.IsEditable = true;
         uc.comb_type.IsEditable = true;
         uc.comb_translator.IsEditable = true;
         uc.comb_examiner.IsEditable = true;
         uc.comb_language.IsEditable = true;
         uc.comb_publisher.IsEditable = true;
         uc.comb_catogray.IsEditable = true;

         uc.comb_author.IsReadOnly = false;
         uc.comb_type.IsReadOnly = false;
         uc.comb_translator.IsReadOnly = false;
         uc.comb_examiner.IsReadOnly = false;
         uc.comb_language.IsReadOnly = false;
         uc.comb_publisher.IsReadOnly = false;
         uc.comb_catogray.IsReadOnly = false;
         uc.label1.Content = "تعديل كتاب: " + x[2].ToString();

         uc.txt_book_id.Text = x[0].ToString();
         uc.txt_book_num.Text= x[1].ToString();
         uc.txt_book_name.Text = x[2].ToString();
         uc.txt_book_dir.Text = x[3].ToString();
         uc.txt_book_partnum.Text = x[4].ToString();
        uc.comb_catogray.Text = x[5].ToString();
         uc.comb_type.Text = x[6].ToString();
         uc.comb_author.Text = x[7].ToString();
         uc.comb_translator.Text = x[8].ToString();
         uc.txt_producing_num.Text = x[9].ToString();
         uc.date_producing.Text = x[10].ToString();
         uc.txt_copiesnum.Text = x[11].ToString();
         uc.txt_book_state.Text = x[12].ToString();
         uc.comb_examiner.Text = x[13].ToString();
         uc.comb_language.Text = x[14].ToString();
         uc.comb_publisher.Text = x[15].ToString();
         uc.txt_room.Text = x[16].ToString();
         uc.txt_floor.Text = x[17].ToString();
         uc.txt_wheel.Text = x[18].ToString();
         uc.txt_shelf.Text = x[19].ToString();
         uc.txt_description.Text = x[20].ToString();


         uc.ShowDialog();
         this.Visibility = Visibility.Collapsed;*/

    }
       
        
    }
    
