using Dapper;
using GarageServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}




            private readonly WebApplication5Context _context;

            public HomeController(WebApplication5Context context)
            {
                _context = context;
            }

            public IActionResult Index()
            {
                var today = DateTime.Today;
                var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

                ViewBag.Total = _context.ServiceReceived.Count();
                ViewBag.Today = _context.ServiceReceived.Count(s => s.ReceivedDate.HasValue && s.ReceivedDate.Value.Date == today);
                ViewBag.ThisMonth = _context.ServiceReceived.Count(s => s.ReceivedDate.HasValue && s.ReceivedDate.Value.Date >= firstDayOfMonth);

                return View();
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
