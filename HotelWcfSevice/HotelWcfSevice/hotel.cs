using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelWcfSevice
{
    [DataContract]
    public class hotel
    {
        [DataMember]
        public int HotelID { get; set; }
        [DataMember]
        public string HotelName { get; set; }
        [DataMember]
        public string HotelAddress { get; set; }
       
        [DataMember]
        public int PinCode { get; set; }
        [DataMember]
        public int HotelRating { get; set; }
      
    }
}