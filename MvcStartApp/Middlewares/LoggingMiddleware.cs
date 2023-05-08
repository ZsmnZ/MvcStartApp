using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Repository;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
           

        }
        public async Task InvokeAsync(HttpContext context, IRequestRepository logRepository)
        {

            var log = new Request()
            {
              Url = context.Request.Path + "/" + context.Request.QueryString
            };

            Console.WriteLine($"Id:[{log.Id}]:Date[{log.Date}] >>> {log.Url}");

            await logRepository.AddLogs(log);
            await _next.Invoke(context);
        }
    }
}
