using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.Exceptions
{
    public class DayLimitException : Exception
    {
        public DayLimitException() : base("Reservations must be for 3 days or less")
        {

        }
    }
}
