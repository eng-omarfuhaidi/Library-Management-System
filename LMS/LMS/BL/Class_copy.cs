using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace LMS.BL
{
    class Class_copy
    {
        
        public void Add_copy(int copy_id, int book_id, string edition, DateTime edition_date, DateTime comming_date,
           int state_id, string part)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@copy_id", SqlDbType.Int);
            param[0].Value = copy_id;

            param[1] = new SqlParameter("@book_id", SqlDbType.Int);
            param[1].Value = book_id;

            param[2] = new SqlParameter("@edition", SqlDbType.VarChar, 50);
            param[2].Value = edition;

            param[3] = new SqlParameter("@edition_date", SqlDbType.Date);
            param[3].Value = edition_date;

            param[4] = new SqlParameter("@comming_date", SqlDbType.Date);
            param[4].Value = comming_date;

            param[5] = new SqlParameter("@state_id", SqlDbType.Int);
            param[5].Value = state_id;

            param[6] = new SqlParameter("@part", SqlDbType.VarChar,50);
            param[6].Value = part;

          

           


            DAL.ExecuteCommand("ADD_copy", param);
            DAL.conclose();



        }
        public DataTable Searhbookname(string name)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;
            Dt = DAL.SelectData("Searchbook_name", param);
            DAL.conclose();
            return Dt;
        }

        public DataTable Searhauthorname(string name)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;
            Dt = DAL.SelectData("Searchauthorname", param);
            DAL.conclose();
            return Dt;
        }

        public DataTable GetcopyByID(int book_id)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@book_id", SqlDbType.Int);
            param[0].Value = book_id;
            Dt = DAL.SelectData("GetcopyByID", param);
            DAL.conclose();
            return Dt;
        }

    }
}
