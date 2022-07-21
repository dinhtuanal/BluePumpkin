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
    public class PrizeConfiguration : IEntityTypeConfiguration<Prize>
    {
        public void Configure(EntityTypeBuilder<Prize> entity)
        {
            entity.HasKey(x=>x.PrizeId);
            entity.Property(x => x.PrizeId).HasDefaultValueSql("(newid())");
            entity.Property(x => x.PrizeName).HasMaxLength(256);
            entity.Property(x => x.Content).HasColumnType("ntext");
            entity.HasOne(e => e.Event)
                .WithMany(p => p.Prizes)
                .HasForeignKey(e => e.EventId)
                .HasConstraintName("FK_Prizes_Event");
        }
    }
}
