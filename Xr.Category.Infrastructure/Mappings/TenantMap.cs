using Xr.System.Domain.Domain;
using Xr.System.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aspros.Project.User.Infrastructure.Repository.Mappings
{
    public class TenantMap : ModelBuilderExtenions.EntityMappingConfiguration<Tenant>
    {
        public override void Map(EntityTypeBuilder<Tenant> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("system_tenant");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.Name);
            entityTypeBuilder.Property(i => i.ContactUserId).HasColumnName("contact_user_id");
            entityTypeBuilder.Property(i => i.ContactName).HasColumnName("contact_name");
            entityTypeBuilder.Property(i => i.ContactMobile).HasColumnName("contact_mobile");
            entityTypeBuilder.Property(i => i.Status);
            entityTypeBuilder.Property(i => i.Website);
            entityTypeBuilder.Property(i => i.PackageId).HasColumnName("package_id");
            entityTypeBuilder.Property(i => i.ExpireTime).HasColumnName("expire_time");
            entityTypeBuilder.Property(i => i.AccountCount).HasColumnName("account_count");
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.CreateTime).HasColumnName("create_time");
            entityTypeBuilder.Property(i => i.Updater);
            entityTypeBuilder.Property(i => i.UpdateTime).HasColumnName("update_time");
            entityTypeBuilder.Property(i => i.Deleted);
        }
    }
}