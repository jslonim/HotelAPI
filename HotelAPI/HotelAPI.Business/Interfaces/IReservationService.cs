using HotelAPI.Business.DTO.Input;
using HotelAPI.Business.DTO.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.Interfaces
{
    public interface IReservationService
    {
        void CreateReservation(CreateReservationInputDTO reservationDTO);

        void DeleteReservation(int id, int customerId);

        void UpdateReservation(UpdateReservationInputDTO reservationDTO);

        List<GetMyReservationsOutputDTO> GetMyReservations(int customerId);
    }
}
