using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SecretsCoreApp.Web.Infrastructure;
using SecretsCoreApp.Web.Models;

namespace SecretsCoreApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseConfig _databaseConfig;
        private readonly ApiConfig _apiConfig;

        public HomeController(ILogger<HomeController> logger, IOptions<ApiConfig> apiConfig, IOptions<DatabaseConfig> databaseConfig)
        {
            _logger = logger;
            _databaseConfig = databaseConfig.Value;
            _apiConfig = apiConfig.Value;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                ApiKey = _apiConfig.Key,
                ConnectionString = _databaseConfig.SecretDbConnString
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
