using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>

    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.Property(i => i.Name)
                .HasColumnName("Name")
                .HasMaxLength(500)
                .IsRequired();
            
            builder.HasOne(i => i.Store)
                .WithMany(i => i.Items)
                .HasForeignKey(i => i.StoreID)
                .IsRequired();

            builder.HasMany(i => i.ItemUnits)
                .WithOne(i => i.Item);
        }
    }
}
