using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class UsersLogic : BaseLogic
    {
        public DataTable GetUsersList(bool fullList)
        {
            SqlCommand command = new SqlCommand();
            if (fullList)
                command.CommandText = "SELECT UserId, LoginName FROM Users order by UserName";
            else
                command.CommandText = "SELECT UserId, LoginName FROM Users where IsConnected = 1 order by UserName";
            DataTable dt = Dal.GetTable(command);
            // insert Empty row at the top
            DataRow row = dt.NewRow();
            dt.Rows.InsertAt(row, 0);
            return dt;
        }

        public void ResetConnection()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE TimeTable SET ConnectionCount = 0, UsersList = NULL, UserId = NULL, LastRequestDate = NULL";
            Dal.ExecuteInsertUpdateDelete(command);
        }

        public DataTable GetPlannerData(int id, string start, string end)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "GetPlannerData";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userId", id);
            command.Parameters.AddWithValue("@start", start);
            command.Parameters.AddWithValue("@end", end);

            DataTable dt = Dal.GetTable(command);

            return dt;
        }

        public int MarkTimeFrame(int id, string start, string end)
        {
            SqlCommand command = new SqlCommand();
            //string retVal;
            command.CommandText = "SchdualeTimeFrame";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userId", id);
            command.Parameters.AddWithValue("@start", start);
            command.Parameters.AddWithValue("@end", end);
            var pInOut = command.Parameters.Add("@retFlag", SqlDbType.Int);
            pInOut.Direction = ParameterDirection.Output;

            string retVal = Dal.ExecuteStoredProcedure(command);
            return System.Convert.IsDBNull(pInOut.Value) ? 0 : (int)pInOut.Value;
        }
    }
}
