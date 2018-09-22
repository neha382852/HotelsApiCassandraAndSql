
using HotelWcfSevice;
using HotelApiService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelApiService.Controllers
{
    public class HotelController : ApiController
    {
        [HttpGet]
        [Route("api/Hotel/GetCombinedDetails")]
         public async System.Threading.Tasks.Task<List<Hotel>> GetCombinedHotelDetailsFromWcfAndJson()
         {
            Logger.Instance.InputLogDetails("Hotel Controller/GetHotelDetailsFromWCFandJson", "Success", "Getting combined details ");
            List<Hotel> hotelslist = new List<Hotel>();
            List<HotelFromJson> HotelListOfJson = new List<HotelFromJson>();
            List<HotelFromWcf> HotelListOfWcf  = new List<HotelFromWcf>();
            System.Threading.Tasks.Task<List<HotelFromWcf>> HotelListOfWcfTask = GetHotelDetailsFromWcf();
            HotelListOfWcf = await HotelListOfWcfTask;
            HotelListOfJson = GetHotelDetailsFromJson();
            for(int index = 0; index < HotelListOfWcf.Count; index++ )
            {
                Hotel hotel = new Hotel();
                hotel.HotelName = HotelListOfWcf[index].HotelName;
                hotel.HotelAddress = HotelListOfWcf[index].HotelAddress;
                hotel.PinCode = HotelListOfWcf[index].PinCode;
                hotel.HotelRating = HotelListOfWcf[index].HotelRating;
                for(int j=0; j< HotelListOfJson.Count;j++)
                {
                    if(HotelListOfJson[j].HotelId == HotelListOfWcf[index].HotelID)
                    {
                        hotel.HotelPolicy = HotelListOfJson[index].HotelPolicy;
                        hotel.HotelContactNumber = HotelListOfJson[index].HotelContactNumber;
                        hotel.HotelAmenities = HotelListOfJson[index].HotelAmenities;
                        hotel.HotelDescription = HotelListOfJson[index].HotelDescription;
                        hotel.HotelImageURL = HotelListOfJson[index].HotelImageURL;
                        break;
                    }
                }
                
                 hotelslist.Add(hotel);
            }
           return hotelslist;
         }
      
         public async System.Threading.Tasks.Task<List<HotelFromWcf>> GetHotelDetailsFromWcf()
        {
            Logger.Instance.InputLogDetails("Hotel Controller/GetHotelDetailsFromWCF", "Success", "Getting hotelsfrom Wcf");
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:53803/HotelService.svc/hotel");
            List<HotelFromWcf> content = new List<HotelFromWcf>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
               content = await response.Content.ReadAsAsync<List<HotelFromWcf>>();
            }
            return content;
           
        }
          public List<HotelFromJson> GetHotelDetailsFromJson()
        {
            Logger.Instance.InputLogDetails("Hotel Controller/GetHotelDetailsFromJson", "Success", "Getting hotels from json");
            string filepath = "C:/Users/nanand/source/repos/HotelApiService/staticcontent.JSON";
            string result = string.Empty;
            List<HotelFromJson> HotelList = new List<HotelFromJson>();
            using (StreamReader streamreader = new StreamReader(filepath))
            {
                var json = streamreader.ReadToEnd();
                HotelList = JsonConvert.DeserializeObject<List<HotelFromJson>>(json);
                return HotelList;
            }

        }

        [HttpGet]
        [Route("api/HotelService/rooms/{hotelname}")]
        public async System.Threading.Tasks.Task<List<Room>> getRoomsOfAHotel(string hotelname)
        {
            Logger.Instance.InputLogDetails("Hotel Controller/getRoomsOfAHotel", "Success", "Getting rooms from hotel");
            List<Room> roomsList = new List<Room>();
            string filepath = "C:/Users/nanand/source/repos/HotelApiService/staticcontent.JSON";
            string result = string.Empty;
            List<HotelFromJson> HotelList = new List<HotelFromJson>();
            using (StreamReader streamreader = new StreamReader(filepath))
            {
                var json = streamreader.ReadToEnd();
                HotelList = JsonConvert.DeserializeObject<List<HotelFromJson>>(json);
                
            }
            string hotelid = null;
            foreach (var hotel in HotelList)
            {
                if (hotel.HotelName == hotelname)
                {
                    hotelid = hotel.HotelId.ToString();
                    break;
                }
            }
            var client = new HttpClient();
            string url = "http://localhost:53803/HotelService.svc/room/" + hotelid;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                roomsList = await response.Content.ReadAsAsync<List<Room>>();

            }
            return roomsList;

        }
    }
}
