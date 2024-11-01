using Microsoft.EntityFrameworkCore;
using MovieReviewApi.Models; 

namespace MovieReviewApi.Data 
{
    // configure sql connection string in appsettings.json
    // register this in startup.cs file

    // bash commands for init create and migration
    // dotnet ef migrations add InitialCreate
    // dotnet ef database update

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for each model in your application
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Cart> Carts { get; set; }
        //public DbSet<PaymentInfo> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define any custom configurations or constraints here

            // Example: Unique constraint on Movie title
            modelBuilder.Entity<Movie>()
                .HasIndex(m => m.Title)
                .IsUnique();

        }
    }
}
