using Xunit;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using SignalR_GoogleMap_Sqlite.Repository.Context;
using SignalR_GoogleMap_Sqlite.Repository;
using SignalR_GoogleMap_Sqlite.Model;
using System;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace SignalR_GoogleMap_Tests.Repository
{
    public class TestSqliteProvider
    {
        // Constants and private variables
        private string OrderTitle = "Order1";
        private double Latitude = 25.15451;
        private double Latitude2 = 27.14521;
        private double Longitude = 21.04544;
        private double Longitude2 = 19.04054;
        private string Status = "Pending";
        private readonly SqliteContext _context;

        // Constructor
        public TestSqliteProvider()
        {
            // Created Test connection for InMemory Sqlite.
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            // Adding connection to the builder.
            var builder = new DbContextOptionsBuilder<SqliteContext>();
            builder.UseSqlite(connection);
            _context = new SqliteContext(builder.Options);
            // Need to ensure the database is created and the schema is generated.
            _context.Database.EnsureCreated();
        }

        [Fact]
        public void Insert_OrderCrudOperation()
        {
            // Arrange
            var provider= new SqliteProvider(_context);
            
            // Act

            // Insert test order detail.
            provider.Insert(new Order{
                Latitude=Latitude,
                Longitude=Longitude,
                OrderTitle=OrderTitle,
                Status=Status});

            // Fetch inserted order detail.
            var orders= provider.GetAll();
            
            // Validate
            Assert.Equal(1, orders.Count);
            Assert.Equal(Latitude, orders.First().Latitude);
            Assert.Equal(Longitude, orders.First().Longitude);
            Assert.Equal(OrderTitle, orders.First().OrderTitle);
            Assert.Equal(Status, orders.First().Status);

            // Fetch Order
            var orders1= provider.GetAll().First();

            // Update Order
            var newOrder= new Order{
                Id=orders1.Id,
                Latitude=Latitude2,
                Longitude=Longitude2,
                Status= orders1.Status,
                OrderTitle= orders1.OrderTitle
            };
            provider.Update(newOrder);

            // Fetching Updated Order
            var orders2= provider.GetAll();

            // Validate
            Assert.Equal(1, orders2.Count);
            Assert.Equal(Latitude2, orders2.First().Latitude);
            Assert.Equal(Longitude2, orders2.First().Longitude);
            Assert.Equal(OrderTitle, orders2.First().OrderTitle);
            Assert.Equal(Status, orders2.First().Status);

            // Remove Test Records
            foreach(var order in orders){
                provider.Remove(order);
            }
            
            // Fetch order detail.
            var orders3= provider.GetAll();

            // Validate
            Assert.Equal(0, orders3.Count);
        }
        
    }
}