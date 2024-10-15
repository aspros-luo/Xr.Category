using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aspros.SaaS.System.Infrastructure.Mappings
{
    public class MenuMap : ModelBuilderExtenions.EntityMappingConfiguration<Menu>
    {
        public override void Map(EntityTypeBuilder<Menu> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("system_menu");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.ParentId).HasColumnName("parent_id");
            entityTypeBuilder.Property(i => i.Path);
            entityTypeBuilder.Property(i => i.Name);
            entityTypeBuilder.Property(i => i.Type);
            entityTypeBuilder.Property(i => i.Sort);
            entityTypeBuilder.Property(i => i.Permission);
            entityTypeBuilder.Property(i => i.Component);
            entityTypeBuilder.Property(i => i.Icon);
            entityTypeBuilder.Property(i => i.Status);
            entityTypeBuilder.Property(i => i.Type);
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.CreateTime).HasColumnName("create_time");
            entityTypeBuilder.Property(i => i.Updater);
            entityTypeBuilder.Property(i => i.UpdateTime).HasColumnName("update_time");
            entityTypeBuilder.Property(i => i.Deleted);
        }
    }
}