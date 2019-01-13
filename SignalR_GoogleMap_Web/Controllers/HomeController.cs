using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_GoogleMap_Web.Models;
using SignalR_GoogleMap_Sqlite.Model;
using SignalR_GoogleMap_Sqlite.Repository;
using SignalR_GoogleMap_Web.Hubs;
using SignalR_GoogleMap_Sqlite.Utility;

namespace SignalR_GoogleMap_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrderFeedHub _hub;
        private readonly ISqliteProvider _provider;
        public HomeController(ISqliteProvider provider)
        {
            _provider = provider;
            _hub = new OrderFeedHub(_provider);
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
                var newOrder = new Order
                {
                    Latitude = order.Latitude,
                    Longitude = order.Longitude,
                    OrderTitle = order.OrderTitle,
                    Status = order.Status
                };
                if (order.OrderId > 0)
                {
                    newOrder.Id = order.OrderId;
                    _provider.Update(newOrder);
                }
                else
                    _provider.Insert(newOrder);
            }
            // Updating hub when a new order is inserted.
            _hub.SendOrderDetail(Utility.ClientSignalRReceivingMethodName);
            return RedirectToAction("index");
        }

        // [HttpPost]
        // public IActionResult UpdateOrder(Order order)
        // {
        //     var newOrder = new OrderViewModel
        //     {
        //         OrderId = order.Id,
        //         Latitude = order.Latitude,
        //         Longitude = order.Longitude,
        //         OrderTitle = order.OrderTitle,
        //         Status = order.Status
        //     };

        //     return RedirectToAction("index");
        // }

        [HttpGet]
        public IActionResult RemoveOrder(int orderId)
        {
            if (orderId > 0)
            {
                var orderDetail = _provider.Get(orderId);
                _provider.Remove(orderDetail);
            }
            // Updating hub when an order is removed.
            _hub.SendOrderDetail(Utility.ClientSignalRReceivingMethodName);
            return RedirectToAction("index");
        }

        public IActionResult Map()
        {
            return View();
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
