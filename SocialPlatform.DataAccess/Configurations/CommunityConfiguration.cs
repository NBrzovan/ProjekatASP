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
    internal class CommunityConfiguration : EntityConfiguration<Community>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Community> builder)
        {
            builder.Property(c => c.Name).IsRequired();

            builder.HasMany(c => c.Questions)
                   .WithOne(q => q.Community)
                   .HasForeignKey(q => q.CommunityId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Users)
                   .WithOne(uc => uc.Community)
                   .HasForeignKey(uc => uc.CommunityId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
