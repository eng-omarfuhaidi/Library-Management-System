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
    /// Interaction logic for UserControlBooks.xaml
    /// </summary>
    public partial class UserControlBooks : UserControl
    {
        MainWindow mn = new MainWindow();
      
       // MainWindow main = new MainWindow();

        public UserControlBooks()
        {
            InitializeComponent();
        }
     
        private void br_addbooks_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MainWindow nm = new MainWindow();


        //    this.Content = new UserControlAddBooks();
          
          /*  UserControlAddBooks uc = new UserControlAddBooks();
            nm.GridMain.Visibility=Visibility.Collapsed;
            nm.Close();
            nm.panelContainer.Children.Add(uc);
      */
           






                      /*MainWindow main = new MainWindow();
          
            Uri uri = new Uri("UserControlAddBooks.xaml", UriKind.Relative);
            NavigationService ns = NavigationService.GetNavigationService(main);
            ns.Navigate(uri);*/
        }

        private void br_addbooks_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow mn = new MainWindow();
            UserControl uc;
          //  UserControl ucn;
            uc = new UserControlBookOPeration();
           // ucn = new UserControlBooks();
            //   mn.GridMain.Children.Remove(ucn);
            mn.GridMain.Children.Add(uc);
            mn.Show();
        
        }

        private void br_addauthor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

           
            UserControl uc;
            uc = new UserControlAddAuothor();
            mn.GridMain.Children.Add(uc);
            mn.Show();
            
        }

        private void br_addcatogray_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl uc;
            uc = new UserControlAddCatogray();
            mn.GridMain.Children.Add(uc);
            mn.Show();
          
        }

        private void br_addpublisher_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl uc;
            uc = new UserControlAddPublisher();
            mn.GridMain.Children.Add(uc);
            mn.Show();

        }

        private void br_addtypes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl uc;
            uc = new UserControlAddType();
            mn.GridMain.Children.Add(uc);
            mn.Show();
        }

        private void br_addlanguage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl uc;
            uc = new UserControlAddLanguage();
            mn.GridMain.Children.Add(uc);
            mn.Show();
        }

        private void br_addexaminer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl uc;
            uc = new UserControlAddExaminer();
            mn.GridMain.Children.Add(uc);
            mn.Show();
        }

        private void br_translator_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl uc;
            uc = new UserControlAddTranslator();
            mn.GridMain.Children.Add(uc);
            mn.Show();
        }
    }
}
