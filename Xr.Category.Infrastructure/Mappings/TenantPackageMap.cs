using Xr.System.Domain.Domain;
using Xr.System.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aspros.Project.User.Infrastructure.Repository.Mappings
{
    public class TenantPackageMap : ModelBuilderExtenions.EntityMappingConfiguration<TenantPackage>
    {
        public override void Map(EntityTypeBuilder<TenantPackage> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("system_tenant_package");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.Name);
            entityTypeBuilder.Property(i => i.Status);
            entityTypeBuilder.Property(i => i.MenuIds).HasColumnName("menu_ids");
            entityTypeBuilder.Property(i => i.Remark);
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.CreateTime).HasColumnName("create_time");
            entityTypeBuilder.Property(i => i.Updater);
            entityTypeBuilder.Property(i => i.UpdateTime).HasColumnName("update_time");
            entityTypeBuilder.Property(i => i.Deleted);
        }
    }
}