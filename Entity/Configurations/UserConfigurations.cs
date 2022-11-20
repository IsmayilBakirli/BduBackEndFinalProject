using Entity.DTOS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<RegisterDto>
    {
        public void Configure(EntityTypeBuilder<RegisterDto> builder)
        {
            builder.Property(n => n.FirstName)
                .IsRequired(true)
                .HasMaxLength(40);
            builder.Property(n => n.LastName)
                .IsRequired(true)
                .HasMaxLength(40);
            builder.Property(n => n.UserName)
              .IsRequired(true)
              .HasMaxLength(40);
            builder.Property(n => n.Email)
              .IsRequired(true);
            builder.Property(n => n.Password)
              .IsRequired(true)
              .HasMaxLength(40);
            builder.HasNoKey();
        }
    }
}
