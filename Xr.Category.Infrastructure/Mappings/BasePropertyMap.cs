using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xr.Category.Domain;

namespace Xr.System.Infrastructure.Mappings
{
    public class BasePropertyMap : ModelBuilderExtenions.EntityMappingConfiguration<BaseProperty>
    {
        public override void Map(EntityTypeBuilder<BaseProperty> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("base_property");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.ParentId).HasColumnName("parent_id");
            entityTypeBuilder.Property(i => i.Name);
            entityTypeBuilder.Property(i => i.PropertyType).HasColumnName("property_type");
            entityTypeBuilder.Property(i => i.Features);
            entityTypeBuilder.Property(i => i.Status);
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.GmtCreated).HasColumnName("gmt_created");
            entityTypeBuilder.Property(i => i.Modifier);
            entityTypeBuilder.Property(i => i.GmtModified).HasColumnName("gmt_modified");
            entityTypeBuilder.Property(i => i.IsDeleted).HasColumnName("is_deleted");
            
            entityTypeBuilder.HasMany(x=>x.CategoryProperties).WithOne(c=>c.BaseProperty).HasForeignKey(p=>p.PropertyId); 
        }
    }
}