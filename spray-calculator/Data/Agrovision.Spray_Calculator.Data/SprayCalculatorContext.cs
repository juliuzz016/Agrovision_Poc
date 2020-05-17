using Agrovision.Spray_Calculator.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Agrovision.Spray_Calculator.Data
{
    public partial class SprayCalculatorContext : DbContext
    {
        public static IConfigurationRoot configuration;
        public SprayCalculatorContext()
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();
        }

        public SprayCalculatorContext(DbContextOptions<SprayCalculatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fields> Fields { get; set; }
        public virtual DbSet<Sprayers> Sprayers { get; set; }
        public virtual DbSet<SprayingAgents> SprayingAgents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SprayCalculatorDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
