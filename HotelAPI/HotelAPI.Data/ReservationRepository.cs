using HotelAPI.Data.Context;
using HotelAPI.Data.Entities;
using HotelAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.Data
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext context;
        public ReservationRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
