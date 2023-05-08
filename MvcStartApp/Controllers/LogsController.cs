using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Repository;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogRepository _logrepo;
        public LogsController(ILogRepository logrepo)
        {
            _logrepo = logrepo;
        }
        public async Task<IActionResult> Index()
        {
            var log = await _logrepo.GetLogs();
            return View(log);
        }
    }
}
