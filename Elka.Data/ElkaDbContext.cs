using System;
using System.Collections.Generic;
using System.Text;
using Elka.Core;
using Microsoft.EntityFrameworkCore;

namespace Elka.Data
{
    public class ElkaDbContext : DbContext
    {
        public ElkaDbContext(DbContextOptions<ElkaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}
