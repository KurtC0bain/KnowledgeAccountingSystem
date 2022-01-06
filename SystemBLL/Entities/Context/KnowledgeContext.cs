using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SystemDAL.Administration.Account.Models;
using SystemDAL.Entities.Knowledges;

namespace SystemDAL.Entities.Context
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
                    Name = "TestArea"
                });

/*            modelBuilder.Entity<Knowledge>().HasData(
                new Knowledge
                {
                    Id = 1,
                    Title = "Junior .Net Developer",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis auctor elit sed vulputate mi sit. Purus sit amet volutpat consequat mauris. Mauris vitae ultricies leo integer malesuada nunc vel. Accumsan tortor posuere ac ut consequat semper viverra. In nibh mauris cursus mattis molestie a iaculis at erat. Vitae nunc sed velit dignissim sodales ut eu. Nunc non blandit massa enim. Ligula ullamcorper malesuada proin libero nunc consequat. Placerat in egestas erat imperdiet sed euismod nisi. Urna condimentum mattis pellentesque id nibh tortor id. Duis tristique sollicitudin nibh sit amet. Ut placerat orci nulla pellentesque dignissim. Id donec ultrices tincidunt arcu non sodales. " +
                    "\n\n" +
                    "Quam elementum pulvinar etiam non quam lacus suspendisse faucibus interdum.Volutpat commodo sed egestas egestas fringilla phasellus faucibus.Bibendum enim facilisis gravida neque convallis a cras semper.Dignissim diam quis enim lobortis.Viverra nam libero justo laoreet.Faucibus turpis in eu mi bibendum.Amet justo donec enim diam vulputate ut pharetra sit amet.Quis enim lobortis scelerisque fermentum dui faucibus.Amet tellus cras adipiscing enim eu.Luctus venenatis lectus magna fringilla urna porttitor rhoncus dolor purus.Cursus risus at ultrices mi tempus.Semper viverra nam libero justo laoreet sit amet cursus.",
                    Areas = new KnowledgeArea[]
                    {
                            new KnowledgeArea
                            {
                                AreaId = 1,
                                Rating = 4
                            },
                            new KnowledgeArea
                            {
                                AreaId = 2,
                                Rating = 3
                            },
                            new KnowledgeArea
                            {
                                AreaId = 3,
                                Rating = 1
                            }
                    }
                },

                new Knowledge
                {
                    Id = 2,
                    Title = "Senior Java Developer",
                    Description = "Dignissim sodales ut eu sem integer vitae justo eget magna. Ullamcorper eget nulla facilisi etiam. Rutrum tellus pellentesque eu tincidunt. Consequat semper viverra nam libero justo laoreet sit amet cursus. Placerat vestibulum lectus mauris ultrices eros in cursus turpis. Viverra mauris in aliquam sem fringilla ut morbi tincidunt augue. Odio ut sem nulla pharetra diam sit amet nisl. Eget nullam non nisi est sit amet. Integer eget aliquet nibh praesent tristique magna sit amet. Diam ut venenatis tellus in metus vulputate eu scelerisque felis. Pulvinar etiam non quam lacus. " +
                    "/n/n" +
                    "Aenean sed adipiscing diam donec.Auctor urna nunc id cursus metus.Eget duis at tellus at urna.Fringilla phasellus faucibus scelerisque eleifend donec.Eget arcu dictum varius duis at.Arcu non sodales neque sodales ut.Laoreet non curabitur gravida arcu.Odio ut enim blandit volutpat maecenas volutpat.Nisl pretium fusce id velit ut tortor.Purus sit amet volutpat consequat mauris nunc congue nisi.Maecenas pharetra convallis posuere morbi leo urna molestie at elementum.Mi sit amet mauris commodo quis imperdiet.Auctor elit sed vulputate mi sit amet mauris commodo quis.Amet justo donec enim diam vulputate ut pharetra sit amet.Tellus elementum sagittis vitae et leo duis ut diam.Quis enim lobortis scelerisque fermentum.Enim nunc faucibus a pellentesque sit amet porttitor eget dolor.Viverra nam libero justo laoreet sit.",
                    Areas = new KnowledgeArea[]
                    {
                            new KnowledgeArea
                            {
                                AreaId = 3,
                                Rating = 5
                            }
                    }
                }
                );
*/
        }
    }
}
