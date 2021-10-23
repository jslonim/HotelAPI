using AutoMapper;
using HotelAPI.Business.DTO.Input;
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
        }
    }
}
