using HotelApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiService
{
    interface IRepository
    {
        void AddBookingDetails(Book obj);
    }
}
