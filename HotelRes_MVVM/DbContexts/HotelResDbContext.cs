using HotelRes_MVVM.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRes_MVVM.DbContexts
{
    public class HotelResDbContext : DbContext
    {
        public HotelResDbContext(DbContextOptions options) : base(options) {}

        public DbSet<ReservationDTO> Reservations { get; set; }
    }
}
