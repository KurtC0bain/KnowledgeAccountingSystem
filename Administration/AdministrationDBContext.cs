using Administration.Account.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration
{
    public class AdministrationDBContext : IdentityDbContext<User>
    {
        public AdministrationDBContext(DbContextOptions<AdministrationDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=;Database=KnowledgeAccountingSystemDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new[]
            {
                new IdentityRole
                {
                    Name = "programmer",
                    NormalizedName = "PROGRAMMER"
                },
                new IdentityRole
                {
                    Name = "manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
            });
        }
    }
}
