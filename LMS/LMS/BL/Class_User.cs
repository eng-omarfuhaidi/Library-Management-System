using LMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BL
{
    class Class_User
    {
      
        public  string username;

        public DataTable GetUserName(string username, string password)
        {
            DataTable dt = DbConnection.ExecuteTable("usp_GetUsername", CommandType.StoredProcedure,
                DbConnection.CreateParameter("@user_name", SqlDbType.VarChar, username),
            DbConnection.CreateParameter("@password", SqlDbType.VarChar, password));
            return dt;
        }


        public void Delet_libclreck(int id)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            DAL.ExecuteCommand("delet_libclirckname", param);
            DAL.conclose();

        }

        public void Set_libclerck(string name)
        {


            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user_name", SqlDbType.VarChar, 50);
            param[0].Value = name;

          


            DAL.ExecuteCommand("set_libclirckname", param);
            DAL.conclose();



        }

    }
}
