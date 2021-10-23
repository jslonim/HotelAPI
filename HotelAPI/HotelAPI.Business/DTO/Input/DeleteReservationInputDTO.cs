using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.DTO.Input
{
    public class DeleteReservationInputDTO
    {
        public int id { get; set; }
        public int customerId { get; set; } 
    }
}
