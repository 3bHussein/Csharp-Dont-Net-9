using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GarageServiceApp.Models;

namespace WebApplication5.Data
{
    public class WebApplication5Context : DbContext
    {
        public WebApplication5Context (DbContextOptions<WebApplication5Context> options)
            : base(options)
        {
        }

        public DbSet<GarageServiceApp.Models.Customer> Customer { get; set; } = default!;
        public DbSet<GarageServiceApp.Models.ServiceReceived> ServiceReceived { get; set; } = default!;
    }
}
