using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GarageServiceApp.Models;

namespace GarageServiceApp.Data
{
    public class GarageServiceAppContext : DbContext
    {
        public GarageServiceAppContext()
        {
        }

        public GarageServiceAppContext (DbContextOptions<GarageServiceAppContext> options)
            : base(options)
        {
        }

        public DbSet<GarageServiceApp.Models.Customer> Customer { get; set; } = default!;
        public DbSet<GarageServiceApp.Models.ServiceReceived> ServiceReceived { get; set; } = default!;
    }
}
