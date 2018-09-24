 
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
    public class BookingController : ApiController
    {
        public void BookRoom([FromBody] Book bookingObject)
        {
            try
            {
                Logger.Instance.InputLogDetails("Booking Controller/BookRoom", "Success", "Booking Details added in SQl");
                Task.Run(() =>
                {
                    string filepath = "C:/Users/nanand/source/repos/HotelApiService/staticcontent.JSON";
                    string result = string.Empty;
                    List<HotelFromJson> HotelList = new List<HotelFromJson>();
                    using (StreamReader streamreader = new StreamReader(filepath))
                    {
                        var json = streamreader.ReadToEnd();
                        HotelList = JsonConvert.DeserializeObject<List<HotelFromJson>>(json);

                    }

                    foreach (var hotel in HotelList)
                    {
                        if (hotel.HotelName == bookingObject.HotelName)
                        {
                            bookingObject.HotelId = hotel.HotelId;
                        }
                    }

                    SqlRepository sqlObject = new SqlRepository();
                    sqlObject.AddBookingDetails(bookingObject);


                });
            }
            catch (Exception e)
            {
                Logger.Instance.InputLogDetails("Booking Controller/BookRoom", "Failure", e.StackTrace);
            }
        }
        [HttpPut]
        public async Task updateCassendra([FromBody] Bookings bookObj)
        {

            Logger.Instance.InputLogDetails("HttpPut/Booking Controller/updateCassendra", "Success", "Rooms table updated in cassandra");
            string filepath = "C:/Users/nanand/source/repos/HotelApiService/staticcontent.JSON";
            string result = string.Empty;
            List<HotelFromJson> HotelList = new List<HotelFromJson>();
            using (StreamReader streamreader = new StreamReader(filepath))
            {
                var json = streamreader.ReadToEnd();
                HotelList = JsonConvert.DeserializeObject<List<HotelFromJson>>(json);

            }

            foreach (var hotel in HotelList)
            {
                if (hotel.HotelName == bookObj.hotelname)
                {
                    bookObj.hotelid = hotel.HotelId.ToString();
                }
            }
            HttpResponseMessage response = null;

            var client = new HttpClient();
            
                string url = "http://localhost:53803/HotelService.svc/hotel";
                response = await client.PutAsJsonAsync(url, bookObj);
            
        }


        
    }
}