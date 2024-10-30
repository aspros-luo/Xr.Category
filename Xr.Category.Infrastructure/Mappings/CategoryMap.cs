using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xr.Category.Domain;

namespace Xr.System.Infrastructure.Mappings
{
    public class CategoryMap : ModelBuilderExtenions.EntityMappingConfiguration<ActionCategory>
    {
        public override void Map(EntityTypeBuilder<ActionCategory> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("action_category");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.ParentId).HasColumnName("parent_id");
            entityTypeBuilder.Property(i => i.Path);
            entityTypeBuilder.Property(i => i.Name);
            entityTypeBuilder.Property(i => i.SortOrder).HasColumnName("sort_order");
            entityTypeBuilder.Property(i => i.IsLeaf).HasColumnName("is_leaf");
            entityTypeBuilder.Property(i => i.Features);
            entityTypeBuilder.Property(i => i.Remark);
            entityTypeBuilder.Property(i => i.Status);
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.GmtCreated).HasColumnName("gmt_created");
            entityTypeBuilder.Property(i => i.Modifier);
            entityTypeBuilder.Property(i => i.GmtModified).HasColumnName("gmt_modified");
            entityTypeBuilder.Property(i => i.IsDeleted).HasColumnName("is_deleted");
        }
    }
}