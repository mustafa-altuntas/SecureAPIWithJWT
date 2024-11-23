using AuthServer.Core.Entities;
using AuthServer.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data.DataContexts
{
    public class SecureApiDbContext : IdentityDbContext<UserApp,IdentityRole,string>
    {
        public SecureApiDbContext(DbContextOptions<SecureApiDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }


    }
}
