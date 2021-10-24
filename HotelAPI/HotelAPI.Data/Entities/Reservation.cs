using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelAPI.Data.Entities
{
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required,Column(Order = 1)]
        public DateTime StartDate {  get; set; }

        [Required, Column(Order = 2)]
        public DateTime EndDate {  get; set; }

        [Required, Column(Order = 3)]
        [MaxLength(50)]
        public string CustomerFullName { get; set; }
    }
}
