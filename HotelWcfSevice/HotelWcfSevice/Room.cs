using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelWcfSevice
{
   
    public class Room
    {
      
        public int Hotelid { get; set; }
     
      
        public string Roomtype { get; set; }
      
        public int Roomprice { get; set; }
       
        public int Roomavailability { get; set; }
    }
}