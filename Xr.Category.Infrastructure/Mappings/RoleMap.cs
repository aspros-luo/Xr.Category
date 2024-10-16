using Xr.System.Domain.Domain;
using Xr.System.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Xr.System.Infrastructure.Mappings
{
    public class RoleMap : ModelBuilderExtenions.EntityMappingConfiguration<Role>
    {
        public override void Map(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("system_role");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.Name);
            entityTypeBuilder.Property(i => i.Code);
            entityTypeBuilder.Property(i => i.Sort);
            entityTypeBuilder.Property(i => i.DataScope).HasColumnName("data_scope");
            entityTypeBuilder.Property(i => i.DataScopeDeptIds).HasColumnName("data_scope_dept_ids");
            entityTypeBuilder.Property(i => i.Status);
            entityTypeBuilder.Property(i => i.Type);
            entityTypeBuilder.Property(i => i.Remark);
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.CreateTime).HasColumnName("create_time");
            entityTypeBuilder.Property(i => i.Updater);
            entityTypeBuilder.Property(i => i.UpdateTime).HasColumnName("update_time");
            entityTypeBuilder.Property(i => i.Deleted);
            entityTypeBuilder.Property(i => i.TenantId).HasColumnName("tenant_id");
        }
    }
}