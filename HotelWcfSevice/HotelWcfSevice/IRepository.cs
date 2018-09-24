using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWcfSevice
{
    interface IRepository
    {
        List<hotel> GetAllHotels();
        List<Room> GetRoomsOfAHotelByHotelId(string hotelid);
    }
}
