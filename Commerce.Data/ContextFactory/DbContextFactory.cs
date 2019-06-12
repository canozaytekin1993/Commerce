using System.Reflection;
using Commerce.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Commerce.Data.ContextFactory
{
    public class DbContextFactory : IDesignTimeDbContextFactory<CommerceDbContext>
    {
        public CommerceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CommerceDbContext>();
            var connection =
                @"Data Source=CanOzaytekin;Initial Catalog=CommerceApplication;Persist Security Info=True;User ID=sa;Password=***********";
            builder.UseSqlServer(connection,
                builder => builder.MigrationsAssembly(typeof(CommerceDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new CommerceDbContext(builder.Options);
        }
    }
}