using Xr.System.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Xr.System.Infrastructure.Mappings
{
    public class UserRoleMap : ModelBuilderExtenions.EntityMappingConfiguration<UserRole>
    {
        public override void Map(EntityTypeBuilder<UserRole> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("system_user_role");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.UserId).HasColumnName("user_id");
            entityTypeBuilder.Property(i => i.RoleIds).HasColumnName("role_ids");
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.CreateTime).HasColumnName("create_time");
            entityTypeBuilder.Property(i => i.Updater);
            entityTypeBuilder.Property(i => i.UpdateTime).HasColumnName("update_time");
            entityTypeBuilder.Property(i => i.Deleted);
            entityTypeBuilder.Property(i => i.TenantId).HasColumnName("tenant_id");

            entityTypeBuilder.HasOne(i => i.User).WithOne(i => i.UserRole).HasForeignKey<UserRole>(i => i.UserId);
        }
    }
}