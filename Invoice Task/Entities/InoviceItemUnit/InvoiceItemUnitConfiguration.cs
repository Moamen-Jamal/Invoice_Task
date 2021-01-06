using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class InvoiceItemUnitConfiguration : IEntityTypeConfiguration<InvoiceItemUnit>

    {
        public void Configure(EntityTypeBuilder<InvoiceItemUnit> builder)
        {
            builder.ToTable("InvoiceItemUnit");
            builder.Property(i => i.Quantity)
                .HasColumnName("Quantity")
                .IsRequired();

            builder.HasOne(i => i.Invoice)
                .WithMany(i => i.InvoiceItemUnits)
                .HasForeignKey(i => i.InvoiceID)
                .IsRequired();

            builder.HasOne(i => i.ItemUnit)
                .WithMany(i => i.InvoiceItemUnits)
                .HasForeignKey(i => i.ItemUnitID)
                .IsRequired();
        }
    }
}
