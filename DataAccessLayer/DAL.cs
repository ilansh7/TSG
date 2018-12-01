using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DAL
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;

        public DAL(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter();
        }

        public void ExecuteInsertUpdateDelete(SqlCommand command)
        {
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public string ExecuteScalar(SqlCommand command)
        {
            command.Connection = conn;
            conn.Open();
            object ret = command.ExecuteScalar();
            conn.Close();
            return (ret == null) ? "" : ret.ToString();
        }

        public string ExecuteStoredProcedure(SqlCommand command)
        {
            string retValue = null; ;
            command.Connection = conn;
            conn.Open();
            command.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader rdr = command.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    retValue = "1";
                    //Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["ProductName"], rdr["Total"]);
                }
            }
            conn.Close();
            return (retValue == null) ? "" : retValue.ToString();
        }


        public DataTable GetTable(SqlCommand command)
        {
            DataTable table = new DataTable();
            command.Connection = conn;
            adapter.SelectCommand = command;
            adapter.Fill(table); // open and close automatically.
            return table;
        }
    }
}
