using System;
using System.Collections.Generic;
using System.Data;
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

namespace LMS
{
    /// <summary>
    /// Interaction logic for Borrowers_list.xaml
    /// </summary>
    public partial class Borrowers_list : Window
    {
        UserControlAddBorrowing uc = new UserControlAddBorrowing();
        BL.ClassBorrower clab = new BL.ClassBorrower();
        public static string ID;
        //  UserControlAddBorrowing uc = new UserControlAddBorrowing();
        public Borrowers_list()
        {
            InitializeComponent();
            dg_borrlist.ItemsSource = clab.GET_ALLBorrowers().DefaultView;
        }

    /*    private void dg_borrlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

                DataRowView x = (DataRowView)dg_borrlist.SelectedItems[0];
                ID = x[0].ToString();
                DataTable dt = clab.GetBoroweresByID(ID);

                foreach (DataRow dr in dt.Rows)
                {
                    uc.txt_borrowingnumber.Text = dr["borrow_id"].ToString();
                    uc.txt_borrowername.Text = dr["borrower_name"].ToString();
                    uc.txt_phone.Text = dr["tel"].ToString();
                    uc.txt_email.Text = dr["email"].ToString();

                    //book_id,book_num,book_name,dirctory_num,part_num,lcat_num,type_id,author_id,translator_id,producing_num,producing_date,copies_num,book_state
                    //,examiner_id,language_id,publisher_id,room_num,floor_num,wheel_num,shelf_num,discription)
                    // txt_book_id.Text = dr["book_id"].ToString();
                }
            
            this.Close();

        }
        */
        private void dg_borrlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid DG = (DataGrid)sender;
            DataRowView row = DG.SelectedItem as DataRowView;
            if (row != null)
            {
              //  uc.txt_borrowingnumber.Text = row[0].ToString();
            }
        }


        // Close();
    }


     
    }

    

