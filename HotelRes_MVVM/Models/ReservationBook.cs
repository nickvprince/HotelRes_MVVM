using HotelRes_MVVM.Exceptions;
using HotelRes_MVVM.Services.ReservationConflictCheckers;
using HotelRes_MVVM.Services.ReservationCreators;
using HotelRes_MVVM.Services.ReservationProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRes_MVVM.Models
{
    public class ReservationBook
    {
        private readonly IReservationProvider _reservationProvider;
        private readonly IReservationCreator _reservationCreator;
        private readonly IReservationConflictChecker _reservationConflictChecker;
        
        public ReservationBook(IReservationProvider reservationProvider, IReservationCreator reservationCreator, IReservationConflictChecker reservationConflictChecker)
        {
            _reservationProvider = reservationProvider;
            _reservationCreator = reservationCreator;
            _reservationConflictChecker = reservationConflictChecker;
        }

        /// <summary>
        /// Get all reservations.
        /// </summary>
        /// <returns>The reservations for the user.</returns>
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationProvider.GetAllReservations();
        }

        /// <summary>
        /// Add a reservation to the reservation book.
        /// </summary>
        /// <param name="reservation">The incoming reservation.</param>
        /// <exception cref="ReservationConflictException">Thrown if incoming reservation conflicts with existing reservation.</exception>
        public async Task AddReservation(Reservation reservation) 
        {
            // Query database for conflicts instead of loading reservations into memory and looping through
            Reservation conflictingReservation = await _reservationConflictChecker.GetConflictingReservation(reservation);

            if (conflictingReservation != null) 
            {
                throw new ReservationConflictException(conflictingReservation, reservation);
            }

            await _reservationCreator.CreateReservation(reservation);
        }

    }
}
