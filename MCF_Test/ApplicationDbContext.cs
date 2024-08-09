using MCF_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace MCF_Test
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<TrBpkb> TrBpkbs { get; set; }
        public DbSet<MsStorageLocation> MsStorageLocations { get; set; }
        public DbSet<MsUser> MsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }
}
