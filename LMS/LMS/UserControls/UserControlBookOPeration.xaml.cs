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

namespace LMS
{
    /// <summary>
    /// Interaction logic for UserControlBookOPeration.xaml
    /// </summary>
    public partial class UserControlBookOPeration : UserControl
    {
        public UserControlBookOPeration()
        {
            InitializeComponent();
        }

        private void br_addbooks_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl ic;
            ic = new UserControlAddBook();
           
            MainWindow mainWindow = new MainWindow();
            mainWindow.GridMain.Children.Add(ic);
            mainWindow.Show();
       
        }

       

        private void book_management_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl ic;
            ic = new UserControlBookManagement();
            BL.Class_book class_ = new BL.Class_book();

            MainWindow mainWindow = new MainWindow();
            mainWindow.GridMain.Children.Add(ic);
            mainWindow.Show();
            class_.windows();
        }

        private void br_addcopy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl ic;
            ic = new UserControlAddCopy();

            MainWindow mainWindow = new MainWindow();
            mainWindow.GridMain.Children.Add(ic);
            mainWindow.Show();
        }
    }
}
