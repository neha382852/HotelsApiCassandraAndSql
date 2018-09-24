using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApiService.Models
{
    public class Book
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public int NoOfRoomsToBeBooked { get; set; }
        public int Price{ get; set; }

    }
}