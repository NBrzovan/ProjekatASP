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
    internal class AnswerConfiguration : EntityConfiguration<Answer>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Answer> builder)
        {
            builder.Property(a => a.QuestionId).IsRequired();
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.Body).IsRequired();
            builder.Property(a => a.ParentId).IsRequired(false);


            builder.HasOne(a => a.ParentAnswer)
                  .WithMany(a => a.Answers)  // Definirajte naziv navigacijskog svojstva u "WithMany" ako postoji
                  .HasForeignKey(a => a.ParentId)
                  .OnDelete(DeleteBehavior.Restrict);

            // Ako se navodni kod koristi, potrebno je zamijeniti odgovarajućim imenom navigacijskog svojstva u "WithMany"
            builder.HasMany(a => a.Answers)
                   .WithOne(a => a.ParentAnswer)
                   .HasForeignKey(a => a.ParentId);
        }
    }
}
