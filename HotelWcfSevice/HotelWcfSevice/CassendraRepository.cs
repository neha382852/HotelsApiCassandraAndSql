using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWcfSevice
{
    
    public class CassendraRepository : IRepository
    {
        Cluster clusterObject = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
        List<hotel> hotelList = new List<hotel>();
        List<Room> roomsList = new List<Room>();
        public List<hotel> GetAllHotels()
        {

            ISession session = clusterObject.Connect("hotels");
            string query = "SELECT * FROM  hotels.hotel";
            var res = session.Execute(query);
            foreach (var row in res)
            {
                int id = row.GetValue<int>("hotelid");
                string hoteladdress = row.GetValue<string>("hoteladdress");
                string hotelname = row.GetValue<string>("hotelname");
                int pincode = row.GetValue<int>("pincode");
                int rating = row.GetValue<int>("rating");
                hotelList.Add(new hotel { HotelID = id, HotelAddress = hoteladdress, HotelName = hotelname, PinCode = pincode, HotelRating = rating });
            }
            return hotelList;
        }

        public List<Room> GetRoomsOfAHotelByHotelId(string id)
        {
            ISession session = clusterObject.Connect("hotels");
            int hotelid = int.Parse(id);
            string query = "SELECT * FROM hotels.Rooms where hotelid = " + hotelid + " ALLOW FILTERING";

            var res = session.Execute(query);
            foreach (var row in res)
            {
                int HotelId = row.GetValue<int>("hotelid");
                string RoomType = row.GetValue<string>("roomtype");
                int NoOfRooms = row.GetValue<int>("noofrooms");
                int Price = row.GetValue<int>("price");

                roomsList.Add(new Room { Hotelid = HotelId, Roomtype = RoomType, Roomavailability = NoOfRooms, Roomprice = Price });
            }
            return roomsList;
        }
        public void update(Bookings bookObject)
        {
            ISession session = clusterObject.Connect("hotels");
            int availablerooms = 0;
            int noRooms = int.Parse(bookObject.NoOfRoomsToBeBooked);
            int id = int.Parse(bookObject.hotelid);
            string query = "SELECT * FROM  hotels.rooms where roomtype= '" + bookObject.roomtype + "' AND hotelid=" + id;
            var res = session.Execute(query);
            foreach (var row in res)
            {
                availablerooms = int.Parse(row.GetValue<int>("noofrooms").ToString());
            }
            availablerooms = availablerooms - noRooms;
            query = "Update hotels.rooms Set noofrooms =  " + availablerooms + " Where roomtype = '" + bookObject.roomtype + "' AND hotelid=" + id;
            session.Execute(query);
        }
    }
}