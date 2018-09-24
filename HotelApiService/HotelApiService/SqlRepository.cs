using HotelApiService.Models;
using HotelWcfSevice;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HotelApiService
{
    public class SqlRepository : IRepository
    {
      public void AddBookingDetails(Book bookingObject)
        {
            try
            {
                string query;
                Logger.Instance.InputLogDetails("SqlRepository/AddBookingDetails", "Success","Booking Details added in SQl");
                SqlConnectionEstablisher obj = new SqlConnectionEstablisher();
                SqlConnection connection = obj.createConnection();
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
            catch(Exception e)
            {
                Logger.Instance.InputLogDetails("SqlRepository/AddBookingDetails", "Failure", e.StackTrace);
            }
        }
    }

   
}