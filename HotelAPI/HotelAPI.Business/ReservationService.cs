using AutoMapper;
using HotelAPI.Business.DTO.Input;
using HotelAPI.Business.DTO.Output;
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
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;   
        }

        public List<CheckRoomAvailabilityOutputDTO> CheckRoomAvailability() 
        {
            List<Reservation> reservationList = _reservationRepository.Find(reservation => reservation.StartDate.Date >= DateTime.Today.Date).ToList();

            List<CheckRoomAvailabilityOutputDTO> reservationListDTO = _mapper.Map<List<CheckRoomAvailabilityOutputDTO>>(reservationList);

            return reservationListDTO;
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
            Reservation reservation = _reservationRepository.GetById(id);
            if (reservation != null)
            {
                _reservationRepository.Delete(reservation.Id);
                _reservationRepository.Save();
            }
            else
            {
                throw new ValidationException("Reservation does not exist");
            }
        }

        public void UpdateReservation(UpdateReservationInputDTO reservationDTO) 
        {
            //Validations regarding dates
            DateValidator.Validate(reservationDTO.StartDate, reservationDTO.EndDate, _reservationRepository, false);

            Reservation reservation = _reservationRepository.GetById(reservationDTO.Id);
            if (reservation != null)
            {            
                _mapper.Map(reservationDTO, reservation);
                _reservationRepository.Update(reservation);
                _reservationRepository.Save();
            }
            else
            {
                throw new ValidationException("Reservation does not exist");
            }

        }
    }
}
