using HotelAPI.Data.Context;
using HotelAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Data
{
    public class ReservationRepository : BaseRepository<Reservation>
    {
        private readonly ApplicationDbContext context;
        public ReservationRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
