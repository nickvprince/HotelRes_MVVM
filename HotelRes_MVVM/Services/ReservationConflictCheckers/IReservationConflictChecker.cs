using HotelRes_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRes_MVVM.Services.ReservationConflictCheckers
{
    public interface IReservationConflictChecker
    {
        Task<Reservation> GetConflictingReservation(Reservation reservation);
    }
}
