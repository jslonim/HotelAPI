using HotelAPI.Business.Interfaces;
using HotelAPI.Data;
using HotelAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business
{
    public class ReservationService : IReservationService
    {
        public IReservationRepository _reservationRepository { get; set; }
        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
    }
}
