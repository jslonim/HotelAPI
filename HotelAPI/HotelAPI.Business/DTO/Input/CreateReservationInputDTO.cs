using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.DTO.Input
{
    public class CreateReservationInputDTO
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CustomerId { get; set; }
    }
}
