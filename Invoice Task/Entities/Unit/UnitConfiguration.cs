using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Unit");
            builder.Property(i => i.Name)
                .HasColumnName("Name")
                .HasMaxLength(500)
                .IsRequired();
            

            builder.HasMany(i => i.ItemUnits)
                .WithOne(i => i.Unit);
        }
    }
}
