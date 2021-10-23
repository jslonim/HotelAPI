using HotelAPI.Business.Exceptions;
using HotelAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelAPI.Business.Validators
{
    public static class DateValidator
    {
        public static void Validate(DateTime startDate, DateTime endDate, IReservationRepository reservationRepository) 
        {
            // Validates for the reservation not being more than 3 days
            if (endDate.Date.Subtract(startDate.Date).Days > 3)
            {
                throw new DayLimitException();
            }

            // Validates for reservation to be within 30 days of the current date, not before nor later.
            if (startDate.Date > DateTime.Today.Date.AddDays(30) || endDate.Date > DateTime.Today.Date.AddDays(30)
                || startDate.Date < DateTime.Today.Date || endDate.Date < DateTime.Today.Date)
            {
                throw new DaysInAdvanceException();
            }

            //Validate if already reserved
            bool isAlreadyReserved = reservationRepository.Find(reservation => startDate <= reservation.EndDate && reservation.StartDate <= endDate).Any();

            if (isAlreadyReserved) 
            {
                throw new ReservedException(); 
            }           
        }
    }
}
