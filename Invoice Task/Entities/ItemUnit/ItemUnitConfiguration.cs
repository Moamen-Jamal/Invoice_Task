using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ItemUnitConfiguration : IEntityTypeConfiguration<ItemUnit>

    {
        public void Configure(EntityTypeBuilder<ItemUnit> builder)
        {
            builder.ToTable("ItemUnit");
            builder.Property(i => i.Price)
                .HasColumnName("Price")
                .IsRequired();

            builder.HasOne(i => i.Item)
                .WithMany(i => i.ItemUnits)
                .HasForeignKey(i => i.ItemID)
                .IsRequired();

            builder.HasOne(i => i.Unit)
                .WithMany(i => i.ItemUnits)
                .HasForeignKey(i => i.UnitID)
                .IsRequired();

            builder.HasMany(i => i.InvoiceItemUnits)
                .WithOne(i => i.ItemUnit);
        }
    }
}
