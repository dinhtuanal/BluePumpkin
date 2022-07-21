using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    public class PrizeDistributionConfiguration : IEntityTypeConfiguration<PrizeDistribution>
    {
        public void Configure(EntityTypeBuilder<PrizeDistribution> entity)
        {
            entity.HasKey(x => x.PrizeDistributionId);
            entity.Property(x => x.PrizeDistributionId).HasDefaultValueSql("(newid())");
        }
    }
}
