using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApiService.Models
{
    public class HotelFromJson
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelContactNumber { get; set; }

        public string HotelDescription { get; set; }

        public string HotelAmenities { get; set; }

        public string HotelPolicy { get; set; }

        public List<string> HotelImageURL { get; set; }
    }
}