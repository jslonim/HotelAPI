using AutoMapper;
using HotelAPI.Business.DTO.Input;
using HotelAPI.Business.DTO.Output;
using HotelAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.Mappings
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<CreateReservationInputDTO, Reservation>();
            CreateMap<UpdateReservationInputDTO, Reservation>();
            CreateMap<GetMyReservationsOutputDTO, Reservation>().ReverseMap();
            CreateMap<CheckRoomAvailabilityOutputDTO, Reservation>().ReverseMap();
        }
    }
}
