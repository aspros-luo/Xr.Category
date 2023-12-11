using System.Reflection;
using Aspros.Base.Framework.Infrastructure.Interface;
using Aspros.SaaS.System.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Aspros.Project.User.Infrastructure.Repository
{
    public class SystemDbContext(DbContextOptions options) : DbContext(options), IDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }
    }
}