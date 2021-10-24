using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelAPI.Business.DTO.Input
{
    public class UpdateReservationInputDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required, MaxLength(50)]
        public string CustomerFullName { get; set; }
    }
}
