using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApiService.Models
{
    public class Hotel
    {
        public string HotelName { get; set; }
    
        public string HotelAddress { get; set; }

        public int PinCode { get; set; }
       
        public int HotelRating { get; set; }

        public string HotelContactNumber { get; set; }

        public string HotelDescription { get; set; }

        public string HotelAmenities { get; set; }

        public string HotelPolicy { get; set; }

        public List<string> HotelImageURL { get; set; }
    }
}