using TruckAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TruckAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }    
    }
}
