using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Repository;

namespace MvcStartApp.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository _logrepo;
        public RequestController(IRequestRepository logrepo)
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
