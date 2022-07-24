using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFM_project.Database.Entities;

namespace PFM_project.Database.Configuration
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("categories");
            builder.HasKey(p=>p.code);
            builder.Property(p=>p.code).IsRequired();
            builder.Property(p=>p.name);
            builder.Property(p=>p.parent_code);

        }
    }
}