using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.NET_Core_Session_Manager.Models;
using ASP.NET_Core_Session_Manager.SesionUtils;

namespace ASP.NET_Core_Session_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionService _sessionService;

        public HomeController(ILogger<HomeController> logger
            , ISessionService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            #region 测试Session管理
            var nameInfo = new
            {
                Name = "马焕鹏",
                Phone = "13429673581",
                Address = "Hangzhou"
            };
            _sessionService.Set<object>(c_NAMESESSIONKEY, nameInfo);
            #endregion
            return View();
        }

        public IActionResult Privacy()
        {
            #region 测试Session管理
            var nameInfoTest= _sessionService.Get<object>(c_NAMESESSIONKEY); 
            #endregion
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private const string c_NAMESESSIONKEY = "basicname";
    }
}
