using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Models.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly BlogContext context;

        public LogRepository(BlogContext context)
        {
            this.context = context;
        }
        public async Task AddLogs(Request req)
        {
            req.Id = Guid.NewGuid();
            req.Date = DateTime.Now;
            var entry = context.Entry(req);
            if(entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                 await context.Logs.AddAsync(req);
            await context.SaveChangesAsync();
        }
        public async Task<Request[]> GetLogs()
        {
            return await context.Logs.ToArrayAsync();
        }

    }
}
