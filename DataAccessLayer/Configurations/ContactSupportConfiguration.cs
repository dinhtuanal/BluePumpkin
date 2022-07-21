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
    public class ContactSupportConfiguration : IEntityTypeConfiguration<ContactSupport>
    {
        public void Configure(EntityTypeBuilder<ContactSupport> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x=>x.Id).HasDefaultValueSql("(newid())");
            entity.Property(x=>x.Name).HasMaxLength(256);
            entity.Property(x=>x.Phone_Number).HasMaxLength(20);
        }
    }
}
