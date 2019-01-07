using Xunit;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using SignalR_GoogleMap_Sqlite.Repository.Context;
using SignalR_GoogleMap_Sqlite.Repository;
using SignalR_GoogleMap_Sqlite.Model;

namespace SignalR_GoogleMap_Tests.Repository
{
    public class TestSqliteProvider
    {
        private string OrderTitle = "Order1";
        [Fact]
        public void Insert_OrderPassed_SavedOrderReturned()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<SqliteContext>();
                // use Sqlite
                builder.UseSqlite(@"Data Source=D:\Experiments\CSharp\SignalR_GoogleMap_RealTimeNotification\SignalR_GoogleMap_Web\Orders.db");
            var dbContext=new SqliteContext(builder.Options);

            // Act
            var provider= new SqliteProvider(dbContext);
            provider.Insert(new Order{Latitude=21.0454,Longitude=25.15451,OrderTitle="Test Order",Status="Pending"});

            var orders= provider.GetAll();
            // Asserts
            Assert.Equal(1, orders.Count);
        }
        
    }

    public static class test{}
}