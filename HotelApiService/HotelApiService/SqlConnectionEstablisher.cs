using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelApiService
{
    public class SqlConnectionEstablisher
    {
        public SqlConnection createConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=TAVDESK045;Initial Catalog=Bookings;User ID=sa;Password=test123!@#";
            return connection;
        }
    }
}