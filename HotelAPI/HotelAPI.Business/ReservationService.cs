using AutoMapper;
using HotelAPI.Business.DTO.Input;
using HotelAPI.Business.Interfaces;
using HotelAPI.Data;
using HotelAPI.Data.Entities;
using HotelAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business
{
    public class ReservationService : IReservationService
    {
        public readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;   
        }

        public void CreateReservation(CreateReservationInputDTO reservationDTO) 
        {

            //if ((reservationDTO.EndDate.Date - reservationDTO.StartDate.Date).TotalDays > 3)
            //{

            //}

            Reservation reservation = _mapper.Map<Reservation>(reservationDTO);

            _reservationRepository.Insert(reservation);

            _reservationRepository.Save();
        }
    }
}
