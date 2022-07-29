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

namespace LMS.DAL
{
    class DbConnection
    {
        //SqlConnection Con = new SqlConnection();
      // DbConnection dbcon = new DbConnection();

         public  SqlConnection Con { get; set; }
        public string conString { get; set; }

       // public string conString = @"Data Source= PC-OA95\OMAR; Initial Catalog= Lib_User; Integrated Security = True;";
      //  public  DbConnection(){
         //  Con = new SqlConnection(@"Data Source= PC-OA95\OMAR; Initial Catalog= Lib_User; Integrated Security = True;");
           
        
        public void conOpen()
            {
        
     //  conString = @"Data Source = ims11.database.windows.net; Initial Catalog = Lib_Sys; User ID = ims111; Password = asd123**; Connect Timeout = 60; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;";
        conString = @"Data Source= .\SQLEXPRESS; Initial Catalog= Lib_Sys; Integrated Security = True;";
              Con = new SqlConnection(conString);
            try
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                Con.Open();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please check the connection.");
                Console.Write("Cannot connect. Check the connection" + ex.Message);
                return;
            }
            }

            public void conclose()
            {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
           conOpen();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = Con;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        //Method to Insert, Update, and Delete Data From Database
        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = Con;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }

         public  static DataTable ExecuteTable(String query, CommandType type, params SqlParameter[] arr)
        {
        // SqlConnection Con = new SqlConnection(@"Data Source = ims11.database.windows.net; Initial Catalog = Lib_Sys; User ID = ims111; Password = asd123**; Connect Timeout = 60; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");
           SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog= Lib_Sys; Integrated Security = True;");

            SqlCommand cmd = new SqlCommand(query,Con);
             cmd.CommandType = type;
             cmd.Parameters.AddRange(arr);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             return dt;
         }
         public static SqlParameter CreateParameter(string name, SqlDbType type, object value)
         {
             SqlParameter pr = new SqlParameter();
             pr.ParameterName = name;
             pr.SqlDbType = type;
             pr.SqlValue = value;
             return pr;

         }

    }
}
