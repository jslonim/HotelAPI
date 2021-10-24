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
        public static void Validate(DateTime startDate, DateTime endDate, IReservationRepository reservationRepository,bool isCreation) 
        {
            // Validates for the reservation not being more than 3 days
            if (endDate.Date.Subtract(startDate.Date).Days > 3)
            {
                throw new ValidationException("Reservations must be for 3 days or less");
            }

            // Validates for reservation to be within 30 days of the current date, not before nor later.
            if (startDate.Date > DateTime.Today.Date.AddDays(30) || endDate.Date > DateTime.Today.Date.AddDays(30)
                || startDate.Date <= DateTime.Today.Date || endDate.Date <= DateTime.Today.Date)
            {
                throw new ValidationException("Reservations must be done within 30 days after today");
            }

            if (isCreation)
            {
                //Validate if already reserved
                bool isAlreadyReserved = reservationRepository.Find(reservation => startDate.Date <= reservation.EndDate.Date && reservation.StartDate.Date <= endDate.Date).Any();

                if (isAlreadyReserved)
                {
                    throw new ValidationException("The room is already reserved for a day in the date range");
                }
            }       
        }
    }
}
