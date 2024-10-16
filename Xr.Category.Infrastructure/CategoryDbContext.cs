using System.Reflection;
using Aspros.Base.Framework.Infrastructure;
using Xr.System.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Aspros.Project.User.Infrastructure.Repository
{
    public class CategoryDbContext(DbContextOptions options) : DbContext(options), IDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }
    }
}