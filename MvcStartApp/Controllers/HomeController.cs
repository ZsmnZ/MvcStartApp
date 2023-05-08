using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Repository;

namespace MvcStartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogRepository _repo;
        private readonly IRequestRepository _logRepository;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repo, IRequestRepository logRepository)
        {
            _logger = logger;
            _repo = repo;
            _logRepository = logRepository;
        }

        public async Task<IActionResult> Index()
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                JoinDate = DateTime.Now,
            };
            await _repo.AddUser(newUser);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"User with id{newUser.Id},named {newUser.FirstName} was successfully added on {newUser.JoinDate}");
            Console.BackgroundColor = ConsoleColor.Black;

            return View();
        }
    }
}