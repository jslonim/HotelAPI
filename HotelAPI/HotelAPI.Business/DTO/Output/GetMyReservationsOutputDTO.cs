using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.DTO.Output
{
    public class GetMyReservationsOutputDTO
    {
        public int Id {  get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
