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
namespace LMS.BL
{
    class Class_book
    {
        MainWindow mn = new MainWindow();
        public DataTable GET_ALL_books()
        {
            DAL.DbConnection dbConnection = new DAL.DbConnection();

            DataTable Dt = new DataTable();
            Dt = dbConnection.SelectData("tblbookselect", null);
            dbConnection.conclose();
            return Dt;
        }

        /*  public static DataTable tblBookSelectByName(string search)
          {
              DataTable dt = DbConnection.("usp_tblStudentSelectByName", CommandType.StoredProcedure,
                  DbConnection.CreateParameter("@search", SqlDbType.NVarChar, search));
              return dt;
          }*/


        public void Add_book(int book_id, string book_name, string dirctory_num, int lcat_num, int type_id, 
            int author_id,int translator_id,int examiner_id,int  language_id,
          int  publisher_id,string  room_num,string floor_num,string wheel_num,string shelf_num,string discription, byte[] book_image)
        {
           
            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@book_id", SqlDbType.Int);
            param[0].Value = book_id;

            param[1] = new SqlParameter("@book_name", SqlDbType.VarChar, 50);
            param[1].Value = book_name;

            param[2] = new SqlParameter("@dirctory_num", SqlDbType.VarChar,50);
            param[2].Value = dirctory_num;

            param[3] = new SqlParameter("@lcat_num", SqlDbType.Int);
            param[3].Value = lcat_num;

            param[4] = new SqlParameter("@type_id", SqlDbType.Int);
            param[4].Value = type_id;

            param[5] = new SqlParameter("@author_id", SqlDbType.Int);
            param[5].Value = author_id;

            param[6] = new SqlParameter("@translator_id", SqlDbType.Int);
            param[6].Value = translator_id;

            param[7] = new SqlParameter("@examiner_id", SqlDbType.Int);
            param[7].Value = examiner_id;

            param[8] = new SqlParameter("@language_id", SqlDbType.Int);
            param[8].Value = language_id;

            param[9] = new SqlParameter("@publisher_id", SqlDbType.Int);
            param[9].Value = publisher_id;

            param[10] = new SqlParameter("@room_num", SqlDbType.VarChar,50);
            param[10].Value = room_num;

            param[11] = new SqlParameter("@floor_num", SqlDbType.VarChar,50);
            param[11].Value = floor_num;

            param[12] = new SqlParameter("@wheel_num", SqlDbType.VarChar,50);
            param[12].Value = wheel_num;

            param[13] = new SqlParameter("@shelf_num", SqlDbType.VarChar,50);
            param[13].Value = shelf_num;

            param[14] = new SqlParameter("@discription", SqlDbType.VarChar, 50);
            param[14].Value = discription;

            param[15] = new SqlParameter("@book_image", SqlDbType.Image);
            param[15].Value = book_image;


            DAL.ExecuteCommand("ADD_book", param);
            DAL.conclose();



        }



        public DataTable Searchbook(string name)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;
            Dt = DAL.SelectData("Searchbookname", param);
            DAL.conclose();
            return Dt;
        }

        public void DeleteBook(string ID)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            DAL.ExecuteCommand("DeleteBook", param);
            DAL.conclose();

        }

        public void windows()
        {
            MainWindow mn = new MainWindow();
            mn.Close();
        }
        public  DataTable usp_GetBookByID(string number)
        {
            DataTable dt = DbConnection.ExecuteTable("usp_GetBookByID", CommandType.StoredProcedure,
                DbConnection.CreateParameter("@book_id", SqlDbType.VarChar, number));
            return dt;
        }

        public void UPDATE_Book(int book_id,  string book_name, string dirctory_num,int lcat_num, int type_id,
                      int  author_id,int translator_id
             ,int examiner_id,int language_id,int publisher_id,string room_num, string floor_num,string wheel_num,string shelf_num,string discription)
         {
           
             DAL.DbConnection DAL = new DAL.DbConnection();
             DAL.conOpen();
             SqlParameter[] param = new SqlParameter[15]; 
             param[0] = new SqlParameter("@book_id", SqlDbType.Int);
             param[0].Value = book_id;

         
             param[1] = new SqlParameter("@book_name", SqlDbType.VarChar, 50);
             param[1].Value = book_name;

           
             param[2] = new SqlParameter("@dirctory_num", SqlDbType.VarChar,50);
             param[2].Value = dirctory_num;

         
             param[3] = new SqlParameter("@lcat_num", SqlDbType.Int);
             param[3].Value = lcat_num;

             param[4] = new SqlParameter("@type_id", SqlDbType.Int);
             param[4].Value = type_id;

             param[5] = new SqlParameter("@author_id", SqlDbType.Int);
             param[5].Value = author_id;

             param[6] = new SqlParameter("@translator_id", SqlDbType.Int);
             param[6].Value = translator_id;


             param[7] = new SqlParameter("@examiner_id", SqlDbType.Int);
             param[7].Value = examiner_id;

             param[8] = new SqlParameter("@language_id", SqlDbType.Int);
             param[8].Value = language_id;

             param[9] = new SqlParameter("@publisher_id", SqlDbType.Int);
             param[9].Value = publisher_id;

             param[10] = new SqlParameter("@room_num", SqlDbType.VarChar,50);
             param[10].Value = room_num;

             param[11] = new SqlParameter("@floor_num", SqlDbType.VarChar,50);
             param[11].Value = floor_num;

             param[12] = new SqlParameter("@wheel_num", SqlDbType.VarChar,50);
             param[12].Value = wheel_num;

             param[13] = new SqlParameter("@shelf_num", SqlDbType.VarChar,50);
             param[13].Value = shelf_num;

             param[14] = new SqlParameter("@discription", SqlDbType.VarChar,50);
             param[14].Value = discription;



             DAL.ExecuteCommand("UPDATE_BOOK", param);
             DAL.conclose();



         }



       }

    }

