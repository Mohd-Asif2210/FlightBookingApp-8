using FlightBookAPI.Models;
using Microsoft.EntityFrameworkCore;
 
namespace FlightBookAPI.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
 
        public virtual DbSet<Flight> Flights { get; set; }
    }
}