using System;
using System.Data;
using System.Data.SqlClient;

namespace DBConnection
{
    public class DBConnect
    {

        public SqlConnection get_connection()
        {
            string connetionString;
            SqlConnection cnn = null;
            try
            {
                connetionString = @"data source=DESKTOP-18M9POD\SQLEXPRESS;initial catalog=master;trusted_connection=true";
                cnn = new SqlConnection(connetionString);
                cnn.Close();
            }
            catch (Exception exc)
            {

            }
            return cnn;

        }

        public DataTable SqlQueryExecutorWithCommand(SqlCommand cmdParam, ref short ExecutionResult, ref string sResult)
        {
            SqlCommand cmd = cmdParam.Clone();
            ExecutionResult = ResponseCodes.FAILED; ;
            // FilterData.FileterDBQuery(ref sQuery);
            DataTable dt = new DataTable();
            SqlConnection connection = get_connection();


            DataTable dtResultTable = new DataTable();
            cmd.CommandType = CommandType.Text;

            cmd.Connection = connection;
            try
            {

                dtResultTable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtResultTable);
                ExecutionResult =   ResponseCodes.SUCCESS; ;
                //return Dataset object on success
            }
            catch (SqlException ex)
            {
                ExecutionResult = ResponseCodes.FAILED;
            }
            catch (Exception ex)
            {
                ExecutionResult = ResponseCodes.FAILED; ;
            }
            return dtResultTable;
        }
        public short SqlNonQueryExecutorWithCommand(SqlCommand cmdParam, ref short ExecutionResult, ref string sResult)
        {
            SqlCommand command = cmdParam.Clone();
            ExecutionResult = ResponseCodes.FAILED; ;
            short rowAffected = 0;
            command.CommandType = CommandType.StoredProcedure;
            SqlConnection connection = get_connection();
            //SqlCommand command = new SqlCommand();
            //command.CommandText = sQuery;
            command.Connection = connection;

            try
            {
                connection.Open();
                rowAffected = Convert.ToInt16(command.ExecuteNonQuery());
                ExecutionResult = ResponseCodes.SUCCESS; ;
            }
            catch (SqlException ex)
            {
                ExecutionResult = ResponseCodes.FAILED;
            }
            catch (Exception ex)
            {
                ExecutionResult = ResponseCodes.FAILED; ;
            }

            //return true on success
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return rowAffected;
        }



    }
}
