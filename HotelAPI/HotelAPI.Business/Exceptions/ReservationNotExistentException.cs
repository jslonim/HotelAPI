using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.Exceptions
{
    public class ReservationNotExistentException : Exception
    {

        public ReservationNotExistentException() : base("Reservation does not exist or belongs to another customer")
        {

        }
    }
}
