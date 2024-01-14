using CodereTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTest.Infrastructure.Context
{
    public class CodereTestContext : DbContext
    {
        public DbSet<ShowItem> ShowItems { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Externals> Externals { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public CodereTestContext(DbContextOptions<CodereTestContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseInMemoryDatabase("CodereTestDB");
    }
}
