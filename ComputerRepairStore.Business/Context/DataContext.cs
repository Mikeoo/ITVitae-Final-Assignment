using ComputerRepairStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ComputerRepairStore.Business.Context
{
    [ExcludeFromCodeCoverage]
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<RepairOrder> RepairOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RepairOrder>().Property(p => p.Photos)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<string>>(v));

            User user = new()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "admin@ad.min",
                LockoutEnabled = false,
                EmailConfirmed = true
            };

            PasswordHasher<User> passwordHasher = new();
            passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<User>().HasData(user);

            builder.Entity<RepairOrder>().Navigation(e => e.Customer).AutoInclude();
            builder.Entity<RepairOrder>().Navigation(e => e.Employee).AutoInclude();
        }
    }
}
