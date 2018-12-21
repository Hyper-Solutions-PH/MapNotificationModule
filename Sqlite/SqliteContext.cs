using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SignalR_GoogleMap_RealTimeNotification.Sqlite{
    public class SqliteContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=order.db");
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Status { get; set; }
    }
}
