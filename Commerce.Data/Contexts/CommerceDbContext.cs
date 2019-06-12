using Commerce.Domain.Entities.Catalog;
using Commerce.Domain.Entities.Media;
using Commerce.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Data.Contexts
{
    public class CommerceDbContext : IdentityDbContext<Person, Role, string>
    {
        public CommerceDbContext(DbContextOptions<CommerceDbContext> builder) : base(builder)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Person>().ToTable("People").Property(p => p.Id).HasColumnName("PersonId");
            builder.Entity<Role>().ToTable("Roles").Property(p => p.Id).HasColumnName("RoleId");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim").Property(x => x.Id)
                .HasColumnName("UserClaimId");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connection =
                @"Data Source=CanOzaytekin;Initial Catalog=CommerceApplication;Persist Security Info=True;User ID=sa;Password=123";
            builder.UseSqlServer(connection);
        }
    }
}