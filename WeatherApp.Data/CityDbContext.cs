using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Core;

namespace WeatherApp.Data
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions<CityDbContext> options)
        : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
    }
}
