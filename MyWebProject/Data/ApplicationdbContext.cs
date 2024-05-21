using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Models;

namespace MyWebProject.Data
{
    public class ApplicationdbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            //modelBuilder.Entity<Product>().HasData(
            //     new Product
            //     {
            //         Id = 1,
            //         Title = "Fortune of Time",
            //         Author = "Billy Spark",
            //         Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
            //         ISBN = "SWD9999001",
            //         ListPrice = 99,
            //         Price = 90,
            //         Price50 = 85,
            //         Price100 = 80,
            //         CategoryId = 1002,
            //         ImageUrl = ""
            //     }
            //     );


        }
    }
}
