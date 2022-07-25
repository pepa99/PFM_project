using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFM_project.Database.Entities;

namespace PFM_project.Database.Configuration
{
    public class TransactionCategoryMappingEntityTypeConfiguration : IEntityTypeConfiguration<TransactionCategoryMapping>
    {
        

        public void Configure(EntityTypeBuilder<TransactionCategoryMapping> builder)
        {
            builder.ToTable("junction");
            builder.HasKey(p=>p.vreme);
            builder.Property(p=>p.vreme);
            builder.Property(p=>p.TransactionID);
            builder.Property(p=>p.CategoryId);
            builder.Property(p=>p.amount);
        }
    }
}