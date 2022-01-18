using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRes_MVVM.DbContexts
{
    class HotelResDesignTimeDbContextFactory : IDesignTimeDbContextFactory<HotelResDbContext>
    {
        public HotelResDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=HotelRes.db").Options;
            return new HotelResDbContext(options);
        }
    }
}
