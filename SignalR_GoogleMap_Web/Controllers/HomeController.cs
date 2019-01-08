using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_GoogleMap_RealTimeNotification.Models;
using SignalR_GoogleMap_Sqlite.Model;
using SignalR_GoogleMap_Sqlite.Repository;

namespace SignalR_GoogleMap_RealTimeNotification.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISqliteProvider _provider;
        public HomeController(ISqliteProvider provider)
        {
            _provider = provider;
        }

        public IActionResult Index()
        {
            ViewBag.orders = _provider.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult SaveOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var newOrder= new Order{
                    Latitude= order.Latitude,
                    Longitude=order.Longitude,
                    OrderTitle= order.OrderTitle,
                    Status=order.Status
                };
                _provider.Insert(newOrder);
            }

            return RedirectToAction("index");
        }

        public IActionResult Technology()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
