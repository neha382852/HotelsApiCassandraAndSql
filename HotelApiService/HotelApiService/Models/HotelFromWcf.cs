using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApiService.Models
{
    public class HotelFromWcf
    {
       
        public int HotelID { get; set; }
        
        public string HotelName { get; set; }
    
        public string HotelAddress { get; set; }

        public int PinCode { get; set; }
       
        public int HotelRating { get; set; }
    }
}