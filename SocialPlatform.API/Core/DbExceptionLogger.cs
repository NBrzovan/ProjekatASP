using SocialPlatform.Application;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;

namespace SocialPlatform.API.Core
{
    public class DbExceptionLogger : IExceptionLogger
    {
        private readonly SocialPlatformContext _context;

        public DbExceptionLogger(SocialPlatformContext context)
        {
            _context = context;
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();

            ErrorLog log = new()
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow
            };

            _context.ErrorLogs.Add(log);

            _context.SaveChanges();

            return id;
        }
    }
}
