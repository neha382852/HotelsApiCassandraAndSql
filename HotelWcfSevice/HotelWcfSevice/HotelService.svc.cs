using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HotelWcfSevice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelService.svc or HotelService.svc.cs at the Solution Explorer and start debugging.
    public class HotelService : IHotelService
    {
        CassendraRepository obj = new CassendraRepository();
        public List<hotel> GetAllHotels()
        {
            return obj.GetAllHotels();
        }

        public List<Room> GetRoomsOfAHotelByHotelId(string id)
        {
            return obj.GetRoomsOfAHotelByHotelId(id);
        }
        public void update(Bookings bookingObject)
        {
            obj.update(bookingObject);
        }
    }
}
