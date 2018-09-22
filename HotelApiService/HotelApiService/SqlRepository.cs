using HotelApiService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HotelApiService
{
    public class SqlRepository : IRepository
    {
      public void AddBookingDetails(Book bookingObject)
        {
            string query;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=TAVDESK045;Initial Catalog=HotelDb;User ID=sa;Password=test123!@#";
          //  SqlConnection connection = obj.createConnection();
            connection.Open();
            query = "insert into Bookings values(@HotelId,@HotelName,@RoomType,@NoOfRoomsToBeBooked,@Price)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(new SqlParameter("@HotelId", bookingObject.HotelId));
            cmd.Parameters.Add(new SqlParameter("@HotelName", bookingObject.HotelName));
            cmd.Parameters.Add(new SqlParameter("@RoomType", bookingObject.RoomType));
            cmd.Parameters.Add(new SqlParameter("@NoOfRoomsToBeBooked", bookingObject.NoOfRoomsToBeBooked));
            cmd.Parameters.Add(new SqlParameter("@Price", bookingObject.Price));
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }

   
}