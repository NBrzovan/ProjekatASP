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
    internal class TopicConfiguration : EntityConfiguration<Topic>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Topic> builder)
        {
            // Postavljanje potrebnih atributa
            builder.Property(t => t.Name).IsRequired();

            // Definiranje navigacijskog svojstva
            builder.HasMany(t => t.Questions)
                   .WithOne(q => q.Topic)
                   .HasForeignKey(q => q.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
