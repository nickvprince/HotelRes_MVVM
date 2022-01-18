using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRes_MVVM.DbContexts
{
    public class HotelResDbContextFactory
    {
        private readonly string _connectionString;

        public HotelResDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public HotelResDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new HotelResDbContext(options);
        }
    }
}
