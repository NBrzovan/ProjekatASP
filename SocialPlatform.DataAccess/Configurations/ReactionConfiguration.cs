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
    internal class ReactionConfiguration : EntityConfiguration<Reaction>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Reaction> builder)
        {
            // Postavljanje potrebnih atributa
            builder.Property(r => r.ReactionType).IsRequired().HasDefaultValue(true);

        }
    }
}
