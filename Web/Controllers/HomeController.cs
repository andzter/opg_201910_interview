using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using opg_201910_interview.Models;
using Microsoft.Extensions.Configuration;
using opg_201910_interview.Lib;

namespace opg_201910_interview.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration config)
        {
            _configuration = config;

        }

        public IActionResult Index()
        {
            var clientId = _configuration.GetValue<string>("ClientSettings:ClientId");
            var filePath = _configuration.GetValue<string>("ClientSettings:FileDirectoryPath");
            return View(OpgFiles.ClientFiles(clientId, filePath));
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
