using HotelAPI.Business.DTO.Input;
using HotelAPI.Business.DTO.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.Interfaces
{
    public interface IReservationService
    {
        List<CheckRoomAvailabilityOutputDTO> CheckRoomAvailability();
        void CreateReservation(CreateReservationInputDTO reservationDTO);

        void DeleteReservation(int id);

        void UpdateReservation(UpdateReservationInputDTO reservationDTO);
    }
}
