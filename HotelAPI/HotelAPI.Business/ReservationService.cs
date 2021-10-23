﻿using AutoMapper;
using HotelAPI.Business.DTO.Input;
using HotelAPI.Business.Exceptions;
using HotelAPI.Business.Interfaces;
using HotelAPI.Business.Validators;
using HotelAPI.Data;
using HotelAPI.Data.Entities;
using HotelAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //Validations regarding dates
            DateValidator.Validate(reservationDTO.StartDate, reservationDTO.EndDate, _reservationRepository);

            Reservation reservation = _mapper.Map<Reservation>(reservationDTO);

            _reservationRepository.Insert(reservation);

            _reservationRepository.Save();
        }
    }
}
