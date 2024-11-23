using AuthServer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data.Configurations
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            // Tablo adı
            builder.ToTable("UserRefreshTokens");

            // UserId alanı
            builder.HasKey(rt => rt.UserId);

            // Code alanı
            builder.HasIndex(rt => rt.Code)
                .IsUnique();

            builder.Property(rt => rt.Code)
                .HasMaxLength(200);


        }
    }
}
