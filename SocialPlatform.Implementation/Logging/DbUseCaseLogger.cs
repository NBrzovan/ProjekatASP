using Newtonsoft.Json;
using SocialPlatform.Application;
using SocialPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Logging
{
    public class DbUseCaseLogger : IUseCaseLogger
    {
        private SocialPlatformContext _context;

        public DbUseCaseLogger(SocialPlatformContext context)
        {
            _context = context;
        }

        public void Log(UseCaseLog log)
        {
            _context.UseCaseLogs.Add(new Domain.UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                Username = log.Username,
                ExecutedAt = DateTime.UtcNow,
                UseCaseData = JsonConvert.SerializeObject(log.UseCaseData)
            });

            _context.SaveChanges();
        }
    }
}
