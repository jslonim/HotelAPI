using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.DTO.Output
{
    public class CheckRoomAvailabilityOutputDTO
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; } = "Reserved";
    }
}
