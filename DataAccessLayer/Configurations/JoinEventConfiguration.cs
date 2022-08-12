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
    public class JoinEventConfiguration : IEntityTypeConfiguration<JoinEvent>
    {
        public void Configure(EntityTypeBuilder<JoinEvent> entity)
        {
            entity.HasKey(x => x.JoinEventId);
            entity.Property(x => x.JoinEventId).HasDefaultValueSql("(newid())");
            entity.Property(x => x.Description).HasColumnType("ntext");
            entity.HasOne(e => e.Event)
                .WithMany(j => j.JoinEvents)
                .HasForeignKey(e => e.EventId)
                .HasConstraintName("FK_JoinEvents_Events");
            entity.HasOne(u => u.ApplicationUser)
                .WithMany(j => j.JoinEvents)
                .HasForeignKey(u => u.UserId)
                .HasConstraintName("FK_JoinEvents_ApplicationUser");

        }
    }
}
