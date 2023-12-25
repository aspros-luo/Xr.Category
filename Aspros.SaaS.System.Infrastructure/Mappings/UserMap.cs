using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aspros.SaaS.System.Infrastructure.Mappings
{
    public class UserMap : ModelBuilderExtenions.EntityMappingConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("system_users");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.UserName).HasColumnName("user_name");
            entityTypeBuilder.Property(i => i.Password).HasColumnName("password");
            entityTypeBuilder.Property(i => i.NickName).HasColumnName("nick_name");
            entityTypeBuilder.Property(i => i.Remark);
            entityTypeBuilder.Property(i => i.DeptId).HasColumnName("dept_id");
            entityTypeBuilder.Property(i => i.PostIds).HasColumnName("post_ids");
            entityTypeBuilder.Property(i => i.Email);
            entityTypeBuilder.Property(i => i.Mobile);
            entityTypeBuilder.Property(i => i.Sex);
            entityTypeBuilder.Property(i => i.Avatar);
            entityTypeBuilder.Property(i => i.Status);
            entityTypeBuilder.Property(i => i.LoginIp).HasColumnName("login_ip");
            entityTypeBuilder.Property(i => i.LoginDate).HasColumnName("login_date");
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.CreateTime).HasColumnName("create_time");
            entityTypeBuilder.Property(i => i.Updater);
            entityTypeBuilder.Property(i => i.UpdateTime).HasColumnName("update_time");
            entityTypeBuilder.Property(i => i.Deleted);
            entityTypeBuilder.Property(i => i.TenantId).HasColumnName("tenant_id");

            entityTypeBuilder.HasOne(i => i.Tenant).WithMany(i => i.Users).HasForeignKey(i => i.TenantId);
        }
    }
}