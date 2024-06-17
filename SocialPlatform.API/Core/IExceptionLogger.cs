using SocialPlatform.Application;

namespace SocialPlatform.API.Core
{
    public interface IExceptionLogger
    {
        Guid Log(Exception ex, IApplicationActor actor);
    }
}

