using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.Exceptions
{
    public class DaysInAdvanceException : Exception
    {
        public DaysInAdvanceException() : base("Reservations must be done within 30 days of the selected date")
        {

        }
    }
}
