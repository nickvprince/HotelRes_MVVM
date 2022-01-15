using Reservoom_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom_MVVM.Exceptions
{
    class ReservationConflictException : Exception 
    { 
        public Reservation ExistingReservation { get; }
        public Reservation IncomingReservation { get; }

        public ReservationConflictException(Reservation existingReservation, Reservation incomingReservation) 
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationConflictException(string message, Reservation existingReservation, Reservation incomingReservation) : base(message) 
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationConflictException(string message, Exception inner, Reservation existingReservation, Reservation incomingReservation) : base(message, inner) 
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }
        
    }
}
