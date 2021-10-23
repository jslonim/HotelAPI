using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.DTO.Input
{
    public class UpdateReservationInputDTO
    {
        public int Id {  get; set; } 
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CustomerId { get; set; }
    }
}
