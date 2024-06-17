using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialPlatform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.DataAccess.Configurations
{
    internal class QuestionConfiguration : EntityConfiguration<Question>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Question> builder)
        {
            // Postavljanje potrebnih atributa
            builder.Property(q => q.Title).IsRequired();
            builder.Property(q => q.Excerpt).IsRequired();
            builder.Property(q => q.Body).IsRequired();

            builder.HasMany(q => q.Answers)
               .WithOne(a => a.Question)
               .HasForeignKey(a => a.QuestionId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.Tags)
                   .WithOne(qt => qt.Question)
                   .HasForeignKey(qt => qt.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.Reactions)
                   .WithOne(r => r.Question)
                   .HasForeignKey(r => r.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
