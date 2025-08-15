using FlightBookingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FlightBookingApp.ApplicationDbContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Flight> flights { get; set; }

        public DbSet<Booking> bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
    }
}
