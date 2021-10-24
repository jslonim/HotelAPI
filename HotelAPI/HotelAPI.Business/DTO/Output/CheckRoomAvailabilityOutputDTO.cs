﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Business.DTO.Output
{
    public class CheckRoomAvailabilityOutputDTO
    {

        public int id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerFullName { get; set; }
    }
}
