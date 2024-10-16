using Xr.System.Domain.Domain;
using Xr.System.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Xr.System.Infrastructure.Mappings
{
    public class RoleMenuMap : ModelBuilderExtenions.EntityMappingConfiguration<RoleMenu>
    {
        public override void Map(EntityTypeBuilder<RoleMenu> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("system_role_menu");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.RoleId).HasColumnName("role_id");
            entityTypeBuilder.Property(i => i.MenuIds).HasColumnName("menu_ids");
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.CreateTime).HasColumnName("create_time");
            entityTypeBuilder.Property(i => i.Updater);
            entityTypeBuilder.Property(i => i.UpdateTime).HasColumnName("update_time");
            entityTypeBuilder.Property(i => i.Deleted);
            entityTypeBuilder.Property(i => i.TenantId).HasColumnName("tenant_id");
            entityTypeBuilder.HasOne(i => i.Role).WithOne(i => i.RoleMenu).HasForeignKey<RoleMenu>(i => i.RoleId);
        }
    }
}