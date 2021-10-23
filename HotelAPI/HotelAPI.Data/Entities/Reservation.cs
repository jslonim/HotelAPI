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

        [Column(Order = 1)]
        public DateTime StartDate {  get; set; }

        [Column(Order = 2)]
        public DateTime EndDate {  get; set; }

        [Column(Order = 3)]
        public int CustomerId {  get; set; }
    }
}
