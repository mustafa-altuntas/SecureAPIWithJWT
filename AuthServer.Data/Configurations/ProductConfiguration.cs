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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            // Tablo adı
            builder.ToTable("Products");

            // Primary Key
            builder.HasKey(p=>p.Id);

            // Name alanı
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);


            // Price alanı
            builder.Property(p=>p.Price)
                .HasColumnType("decimanl(18,2)")
                .IsRequired();

            // Stock alanı
            builder.Property(p => p.Stock)
                .IsRequired();

            // CreatedAt alanı
            builder.Property(p => p.CreatedAt)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
            //.HasDefaultValueSql("GETDATE()")

            //UserId alanı
            builder.Property(p => p.UserId)
                .IsRequired();


            // Ekstra Index
            builder.HasIndex(p => p.Name)
                .HasDatabaseName("IX_Products_Name");
                

        }
    }
}
