
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFM_project.Database.Entities;

namespace PFM_project.Database.Configuration
{
    public class TransactionsEntityTypeConfiguration : IEntityTypeConfiguration<TransactionsEntity>
    {
        

        public void Configure(EntityTypeBuilder<TransactionsEntity> builder)
        {
            builder.ToTable("transactions");
            builder.HasKey(p=>p.id);
            builder.Property(p =>p.id).IsRequired();
            builder.Property(p=>p.date).IsRequired();
            builder.Property(p=>p.Directions).HasConversion<string>().IsRequired();
            builder.Property(p=>p.amount).IsRequired();
            builder.Property(p=>p.beneficiaryname);
            builder.Property(p=>p.TransactionKind).HasConversion<string>().IsRequired();
            builder.Property(p=>p.currency).IsRequired().HasMaxLength(3);
            builder.Property(p=>p.mcc);
            builder.Property(p=>p.description);
            builder.Property(p=>p.catcode);
            builder.Property(p=>p.splits);
        }
    }
}