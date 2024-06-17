using SocialPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(SocialPlatformContext context)
        {
            Context = context;
        }

        protected SocialPlatformContext Context { get; }
    }
}
