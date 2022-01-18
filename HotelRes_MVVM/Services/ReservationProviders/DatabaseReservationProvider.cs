using HotelRes_MVVM.DbContexts;
using HotelRes_MVVM.DTOs;
using HotelRes_MVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRes_MVVM.Services.ReservationProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {

        private readonly HotelResDbContextFactory _dbContextFactory;

        public DatabaseReservationProvider(HotelResDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using (HotelResDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();
                return reservationDTOs.Select(r => ToReservation(r));
            }
        }

        private static Reservation ToReservation(ReservationDTO r)
        {
            return new Reservation(new RoomID(r.FloorNumber, r.RoomNumber), r.Username, r.StartTime, r.EndTime);
        }
    }
}
