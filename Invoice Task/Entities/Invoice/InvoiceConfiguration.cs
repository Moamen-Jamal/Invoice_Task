using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");

            builder.Property(i => i.Total)
                .HasColumnName("Total")
                .IsRequired();

            builder.Property(i => i.Taxes)
                .HasColumnName("Taxes")
                .IsRequired();

            builder.Property(i => i.Net)
                .HasColumnName("Net")
                .IsRequired();

            builder.Property(i => i.Date)
                .HasColumnName("Date")
                .IsRequired();
            builder.HasMany(i => i.InvoiceItemUnits)
                .WithOne(i => i.Invoice);
        }
    }
}
