using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDAL.Entities.Knowledges.Context
{
    public class KnowladgeContext : DbContext
    {
        public KnowladgeContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<Area> Areas { get; set; }
    }
}
