using DataAccessLayer.Configurations;
using DataAccessLayer.Entities;
using DataAccessLayer.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbContext
{
    public class BluePumpkinDbContext : IdentityDbContext<ApplicationUser>
    {
        public BluePumpkinDbContext(DbContextOptions<BluePumpkinDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ContactSupportConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new JoinEventConfiguration());
            builder.ApplyConfiguration(new PrizeConfiguration());
            builder.ApplyConfiguration(new PrizeDistributionConfiguration());
            builder.ApplyConfiguration(new TestConfiguration());
            //builder.Seed();
        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<ContactSupport> ContactSupports{ get; set; }
        public DbSet<JoinEvent> JoinEvents{ get; set; }
        public DbSet<Event> Events{ get; set; }
        public DbSet<Prize> Prizes{ get; set; }
        public DbSet<PrizeDistribution> PrizeDistributions{ get; set; }

    }
}
