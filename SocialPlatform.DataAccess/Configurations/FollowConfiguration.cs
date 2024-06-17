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
    internal class FollowConfiguration : EntityConfiguration<Follow>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Follow> builder)
        {
            builder.Property(f => f.FollowerId).IsRequired();
            builder.Property(f => f.UserId).IsRequired();
        }
    }
}
