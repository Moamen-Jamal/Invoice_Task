using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class BaseModelConfiguration
        : IEntityTypeConfiguration<BaseModel>
    {
        public void Configure(EntityTypeBuilder<BaseModel> builder)
        {
            builder.HasKey(i => i.ID);
            builder.Property(i => i.ID)
                .ValueGeneratedOnAdd();
        }
    }
}
