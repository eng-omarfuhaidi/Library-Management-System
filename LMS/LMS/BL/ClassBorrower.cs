using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.DAL;
namespace LMS.BL
{
    class ClassBorrower
    {


        //    [Searchborrower_information]




        public DataTable search_borr_by_name(string name)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;
            Dt = DAL.SelectData("search_borr_by_name", param);
            DAL.conclose();
            return Dt;
        }






        public DataTable search_borr_by_date(string return_date)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@return_date", SqlDbType.VarChar, 50);
            param[0].Value = return_date;
            Dt = DAL.SelectData("search_loan_by_date", param);
            DAL.conclose();
            return Dt;
        }




        public DataTable Searchborrower_information(string name)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;
            Dt = DAL.SelectData("Searchborrower_information", param);
            DAL.conclose();
            return Dt;
        }

        public DataTable Searchborrower_2(string name)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;
            Dt = DAL.SelectData("Searchborrowername_2", param);
            DAL.conclose();
            return Dt;
        }


        public DataTable Searchborrower(string name)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;
            Dt = DAL.SelectData("Searchborrowername", param);
            DAL.conclose();
            return Dt;
        }

        public void add_loan(string loan_id, string loan_disc, string loan_date, string lender_name, int borrowed_id, string return_date, int loan_period)
        {


            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@loan_id", SqlDbType.VarChar, 25);
            param[0].Value = loan_id;

            param[1] = new SqlParameter("@loan_disc", SqlDbType.VarChar, 50);
            param[1].Value = loan_disc;

            param[2] = new SqlParameter("@loan_date", SqlDbType.VarChar, 50);
            param[2].Value = loan_date;

            param[3] = new SqlParameter("@lender_name", SqlDbType.VarChar, 50);
            param[3].Value = lender_name;

            param[4] = new SqlParameter("@borrowed_id", SqlDbType.Int);
            param[4].Value = borrowed_id;

            param[5] = new SqlParameter("@return_date", SqlDbType.VarChar, 50);
            param[5].Value = return_date;

            param[6] = new SqlParameter("@loan_period", SqlDbType.Int);
            param[6].Value = loan_period;



            DAL.ExecuteCommand("ADD_loan", param);
            DAL.conclose();



        }


        public void add_loandetails(string loan_id, int copy_id
          , int book_id)
        {


            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@loan_id", SqlDbType.VarChar, 25);
            param[0].Value = loan_id;

            param[1] = new SqlParameter("@copy_id", SqlDbType.Int);
            param[1].Value = copy_id;


            param[2] = new SqlParameter("@book_id", SqlDbType.Int);
            param[2].Value = book_id;

            DAL.ExecuteCommand("ADD_loandetails", param);
            DAL.conclose();
        }



        public void Add_Borrower(int borro_id, string borrower_name, string tel,
                   string email, string user_name, string password,  int borrowertype_id, string
        notes, byte[] borrower_image, int allowable, string Criterion)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@borro_id", SqlDbType.Int);
            param[0].Value = borro_id;

            param[1] = new SqlParameter("@borrower_name", SqlDbType.VarChar, 50);
            param[1].Value = borrower_name;

        
            param[2] = new SqlParameter("@tel", SqlDbType.VarChar, 50);
            param[2].Value = tel;

            param[3] = new SqlParameter("@email", SqlDbType.VarChar, 50);
            param[3].Value = email;

            param[4] = new SqlParameter("@user_name", SqlDbType.VarChar, 50);
            param[4].Value = user_name;

            param[5] = new SqlParameter("@password", SqlDbType.VarChar, 25);
            param[5].Value = password;

          

            param[6] = new SqlParameter("@borrowertype_id", SqlDbType.Int);
            param[6].Value = borrowertype_id;

            param[7] = new SqlParameter("@notes", SqlDbType.VarChar, 50);
            param[7].Value = notes;

            

            param[8] = new SqlParameter("@borrower_image", SqlDbType.Image);
            param[8].Value = borrower_image;

            param[9] = new SqlParameter("@allowable", SqlDbType.Int);
            param[9].Value = allowable;

            param[10] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[10].Value = Criterion;

            DAL.ExecuteCommand("Add_Borrower", param);
            DAL.conclose();

        }

        public DataTable GET_ALLBorrowers()
        {
            DAL.DbConnection dbConnection = new DAL.DbConnection();

            DataTable Dt = new DataTable();
            Dt = dbConnection.SelectData("Get_AllBorrowers", null);
            dbConnection.conclose();
            return Dt;
        }

        public DataTable GetBoroweresByID(string number)
        {
            DataTable dt = DbConnection.ExecuteTable("getBorrowersByID", CommandType.StoredProcedure,
                DbConnection.CreateParameter("@borrower_id", SqlDbType.VarChar, number));
            return dt;
        }

        public DataTable GetBoroweresByName(string number)
        {
            DataTable dt = DbConnection.ExecuteTable("getBorrowersByName", CommandType.StoredProcedure,
                DbConnection.CreateParameter("@borrower_name", SqlDbType.VarChar, number));
            return dt;
        }



        public DataTable GetDetailesByLoanID(int number)
        {
            DataTable dt = DbConnection.ExecuteTable("GetDetailesByLoanID", CommandType.StoredProcedure,
                DbConnection.CreateParameter("@loan_id", SqlDbType.Int, number));
            return dt;
        }


        public DataTable GET_AllLoans()
        {
            DAL.DbConnection dbConnection = new DAL.DbConnection();

            DataTable Dt = new DataTable();
            Dt = dbConnection.SelectData("Get_AllLoans", null);
            dbConnection.conclose();
            return Dt;
        }


        public DataTable GET_AllLoans_inblack()
        {
            DAL.DbConnection dbConnection = new DAL.DbConnection();

            DataTable Dt = new DataTable();
            Dt = dbConnection.SelectData("Get_AllLoans_inblack", null);
            dbConnection.conclose();
            return Dt;
        }

        //   [Get_AllLoans_laters]

        public DataTable GET_Allrequest()
        {
            DAL.DbConnection dbConnection = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            Dt = dbConnection.SelectData("Get_Allrequest", null);
            dbConnection.conclose();
            return Dt;
        }




        public DataTable GET_All_laters()
        {
            DAL.DbConnection dbConnection = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            Dt = dbConnection.SelectData("Get_AllLoans_laters", null);
            dbConnection.conclose();
            return Dt;
        }



        public DataTable GET_Alljoining()
        {
            DAL.DbConnection dbConnection = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            Dt = dbConnection.SelectData("Get_Alljoining", null);
            dbConnection.conclose();
            return Dt;
        }

        public DataTable Getjoiningrequestdata(int request_id)
        {
            DataTable dt = DbConnection.ExecuteTable("usp_Getjoiningbyid", CommandType.StoredProcedure,
                DbConnection.CreateParameter("@request_id", SqlDbType.VarChar, request_id));
            return dt;
        }


        public DataTable Getloanlater(string returndate)
        {
            DataTable dt = DbConnection.ExecuteTable("Get_AllLoanlater", CommandType.StoredProcedure,
                DbConnection.CreateParameter("@return_date", SqlDbType.VarChar, returndate));
            return dt;
        }



        public void add_loanlater(string loanlater_id, string loanlater_disc, string loanlater_date, string lender_name, int borrowed_id, string returnlater_date, int loanlater_period)
        {


            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@loanlater_id", SqlDbType.VarChar, 25);
            param[0].Value = loanlater_id;

            param[1] = new SqlParameter("@loanlater_disc", SqlDbType.VarChar, 50);
            param[1].Value = loanlater_disc;

            param[2] = new SqlParameter("@loanlater_date", SqlDbType.VarChar, 50);
            param[2].Value = loanlater_date;

            param[3] = new SqlParameter("@lender_name", SqlDbType.VarChar, 50);
            param[3].Value = lender_name;

            param[4] = new SqlParameter("@borrowed_id", SqlDbType.Int);
            param[4].Value = borrowed_id;

            param[5] = new SqlParameter("@returnlater_date", SqlDbType.VarChar, 50);
            param[5].Value = returnlater_date;

            param[6] = new SqlParameter("@loanlater_period", SqlDbType.Int);
            param[6].Value = loanlater_period;



            DAL.ExecuteCommand("ADD_loanlater", param);
            DAL.conclose();



        }





        public void acceptJoininrequest(int borrow_id, string borrower_name, string email,
            string user_name, string password, int borrowertype_id, string notes, int allowable)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@borrow_id", SqlDbType.Int);
            param[0].Value = borrow_id;

            param[1] = new SqlParameter("@borrower_name", SqlDbType.VarChar, 50);
            param[1].Value = borrower_name;

            param[2] = new SqlParameter("@email", SqlDbType.VarChar, 50);
            param[2].Value = email;

            param[3] = new SqlParameter("@user_name", SqlDbType.VarChar, 50);
            param[3].Value = user_name;

            param[4] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            param[4].Value = password;

            param[5] = new SqlParameter("@borrowertype_id", SqlDbType.Int);
            param[5].Value = borrowertype_id;

            param[6] = new SqlParameter("@notes", SqlDbType.VarChar, 50);
            param[6].Value = notes;



            param[7] = new SqlParameter("@allowable", SqlDbType.Int);
            param[7].Value = allowable;




            DAL.ExecuteCommand("Get_acceptjoin", param);
            DAL.conclose();



        }






        public void UPDATE_reservingstate(int copy_id, int requist_id)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@copy_id", SqlDbType.Int);
            param[0].Value = copy_id;
            param[1] = new SqlParameter("@reserve_request_id", SqlDbType.Int);
            param[1].Value = requist_id;
            DAL.ExecuteCommand("UPDATE_reservingstate", param);
            DAL.conclose();



        }



        public void UPDATE_joiningrequeststate(int joining_request_id)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@joining_request_id", SqlDbType.Int);
            param[0].Value = joining_request_id;

            DAL.ExecuteCommand("UPDATE_joiningstate", param);
            DAL.conclose();


        }

        public void Deleteoldloanlater(string date)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@date", SqlDbType.VarChar, 50);
            param[0].Value = date;
            DAL.ExecuteCommand("Deleteoldloanlater", param);
            DAL.conclose();

        }

        public void UPDATE_borowe(int borrow_id, string borrower_name, string tel, 
            string email, string user_name,
                     string password, int borrowertype_id
            , string notes, Byte[] borrower_image, int allowable)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@borrow_id", SqlDbType.Int);
            param[0].Value = borrow_id;


            param[1] = new SqlParameter("@borrower_name", SqlDbType.VarChar, 50);
            param[1].Value = borrower_name;


            param[2] = new SqlParameter("@tel", SqlDbType.VarChar, 50);
            param[2].Value = tel;


            param[3] = new SqlParameter("@email", SqlDbType.VarChar, 50);
            param[3].Value = email;

            param[4] = new SqlParameter("@user_name", SqlDbType.VarChar, 50);
            param[4].Value = user_name;

            param[5] = new SqlParameter("@password", SqlDbType.VarChar,25);
            param[5].Value = password;

            param[6] = new SqlParameter("@borrowertype_id", SqlDbType.Int);
            param[6].Value = borrowertype_id;


            param[7] = new SqlParameter("@notes", SqlDbType.VarChar,50);
            param[7].Value = notes;

            param[8] = new SqlParameter("@borrower_image", SqlDbType.Image);
            param[8].Value = borrower_image;

            param[9] = new SqlParameter("@allowable", SqlDbType.Int);
            param[9].Value = allowable;

           


            DAL.ExecuteCommand("UPDATE_borrower", param);
            DAL.conclose();



        }


        public void update_reserving_state(string reverse_date)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@reverse_date", SqlDbType.VarChar, 50);
            param[0].Value = reverse_date;
            DAL.ExecuteCommand("update_reserving_state", param);
            DAL.conclose();

        }



       

        public void cancel_request(string reverse_date)
        {
            DAL.DbConnection DAL = new DAL.DbConnection();
            DAL.conOpen();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@reverse_date", SqlDbType.VarChar,50);
            param[0].Value = reverse_date;
            DAL.ExecuteCommand("cancel_request_copy", param);
            DAL.conclose();

        }


        public DataTable Update_avaliable_number(string reversing_date)
        {
            DataTable dt = DbConnection.ExecuteTable("Update_valuenumber", CommandType.StoredProcedure,
                DbConnection.CreateParameter("@reverse_date", SqlDbType.VarChar, reversing_date));
            return dt;


        }
        public DataTable search_borrowerblackbyname(string name)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;
            Dt = DAL.SelectData("search_LoanBlack_by_name", param);
            DAL.conclose();
            return Dt;
        }


        public DataTable search_borrowerblackbydate(string return_date)
        {

            DAL.DbConnection DAL = new DAL.DbConnection();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@return_date", SqlDbType.VarChar, 50);
            param[0].Value = return_date;
            Dt = DAL.SelectData("search_LoanBlack_by_date", param);
            DAL.conclose();
            return Dt;
        }

    }

    }
