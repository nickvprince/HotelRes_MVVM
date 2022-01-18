using HotelRes_MVVM.DbContexts;
using HotelRes_MVVM.DTOs;
using HotelRes_MVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRes_MVVM.Services.ReservationConflictCheckers
{
    public class DatabaseReservationConflictChecker : IReservationConflictChecker
    {
        private readonly HotelResDbContextFactory _dbContextFactory;

        public DatabaseReservationConflictChecker(HotelResDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Reservation> GetConflictingReservation(Reservation reservation)
        {
            using (HotelResDbContext context = _dbContextFactory.CreateDbContext())
            {
               return await context.Reservations
                    .Select(r => ToReservation(r))
                    .FirstOrDefaultAsync(r => r.Conflicts(reservation));
            }
        }

        private static Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(new RoomID(dto.FloorNumber, dto.RoomNumber), dto.Username, dto.StartTime, dto.EndTime);
        }
    }
}
