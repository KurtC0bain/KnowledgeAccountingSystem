using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDAL.Entities.Knowledges;

namespace SystemDAL.Entities.Context
{
    public class KnowledgeContext : DbContext
    {
        public KnowledgeContext(DbContextOptions<KnowledgeContext> options)
            : base(options)
        { }
        public KnowledgeContext()
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=;Database=KnowledgeAccountingSystemDB;Trusted_Connection=True");
        }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<Area> Areas { get; set; }
    }
}
