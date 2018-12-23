using System.Collections.Generic;
using System.Linq;

namespace SignalR_GoogleMap_RealTimeNotification.Sqlite{
    public class SqliteProvider
    {
        private SqliteContext _context;
        public List<Order> InsertRawData()
        {
            using (var db = new SqliteContext())
            {
                db.Orders.Add(new Order { 
                    Longitude = 77.787708,
                    Latitude = 27.498527,
                    Status = "Pending" });
                var count = db.SaveChanges();
                
                return db.Orders.ToList();
            }
        }

        public List<Order> CreateOrder(double longitude, double latitude)
        {
            using (var db = new SqliteContext())
            {
                db.Orders.Add(new Order { 
                    Longitude = longitude,
                    Latitude = latitude,
                    Status = "Pending" });
                var count = db.SaveChanges();
                
                return db.Orders.ToList();
            }
        }

        public List<Order> FetchOrders()
        {
            using (var db = new SqliteContext())
            {
            return db.Orders.ToList();
            }
        }
    }
}