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
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.HasKey(x => x.EventId);
            entity.Property(e => e.EventId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.EventName).HasMaxLength(256);
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.TimeStart).HasColumnType("datetime");
            entity.Property(e => e.TimeEnd).HasColumnType("datetime");
        }
    }
}
