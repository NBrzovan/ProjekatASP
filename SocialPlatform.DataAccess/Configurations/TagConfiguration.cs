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
    internal class TagConfiguration : EntityConfiguration<Tag>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Tag> builder)
        {
            // Postavljanje potrebnih atributa
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Description).IsRequired();

            // Definiranje navigacijskog svojstva
            builder.HasMany(t => t.Questions)
                   .WithOne(qt => qt.Tag)
                   .HasForeignKey(qt => qt.TagId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
