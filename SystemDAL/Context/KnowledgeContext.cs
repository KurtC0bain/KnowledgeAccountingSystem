using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SystemDAL.Entities.Knowledges;
using SystemDAL.Entities.Users;

namespace SystemDAL.Context
{
    public class KnowledgeContext : IdentityDbContext<User>
    {
        public KnowledgeContext(DbContextOptions<KnowledgeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public KnowledgeContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=;Database=KnowledgeAccountingSystemDB;Trusted_Connection=True");
        }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<KnowledgeArea> KnowledgeAreas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityRole>().HasData(new[]
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

            modelBuilder.Entity<Area>().HasData(
                new Area
                {
                    Id = 1,
                    Name = "ASP.NET"
                },
                new Area
                {
                    Id = 2,   
                    Name = "Angular"
                },
                new Area
                {
                    Id = 3,
                    Name = "Java"
                }, 
                new Area
                {
                    Id = 4,
                    Name = "RUST"
                },
                new Area
                {
                    Id = 5,
                    Name = "C++"
                },
                new Area
                {
                    Id = 6,
                    Name = "PHP"
                });
        }
    }
}
