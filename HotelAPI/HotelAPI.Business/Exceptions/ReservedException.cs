using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.Exceptions
{
    public class ReservedException : Exception
    {
        public ReservedException() : base("The room is already reserved for a day in the date range")
        {

        }
    }
}
