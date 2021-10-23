using AutoMapper;
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
            DateValidator.Validate(reservationDTO.StartDate, reservationDTO.EndDate, _reservationRepository,true);

            Reservation reservation = _mapper.Map<Reservation>(reservationDTO);

            _reservationRepository.Insert(reservation);

            _reservationRepository.Save();
        }

        public void DeleteReservation(int id) 
        {
            bool reservationExists = _reservationRepository.Find(reservation => reservation.Id == id).Any();

            if (reservationExists)
            {
                _reservationRepository.Delete(id);
                _reservationRepository.Save();
            }
            else
            {
                throw new ReservationNotExistentException();
            }
        }

        public void UpdateReservation(UpdateReservationInputDTO reservationDTO) 
        {
            //Validations regarding dates
            DateValidator.Validate(reservationDTO.StartDate, reservationDTO.EndDate, _reservationRepository, false);

            Reservation reservation = _mapper.Map<Reservation>(reservationDTO);

            _reservationRepository.Update(reservation);
            _reservationRepository.Save();
        }
    }
}
