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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> entity)
        {
            entity.HasKey(x => x.QuestionId);
            entity.Property(x => x.QuestionId).HasDefaultValueSql("(newid())");
            entity.Property(x=>x.Title).HasMaxLength(500);
            entity.Property(x => x.Answer).HasColumnType("ntext");
        }
    }
}
