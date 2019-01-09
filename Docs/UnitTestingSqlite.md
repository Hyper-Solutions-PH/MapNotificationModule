# Testing Application - XUnit
Following Test Driven Development is a great practice to improve your coding skills. I would suggest you to follow it wisely. To explain test driven development I am adding a link with this article will suggest you to have a look.

https://www.linkedin.com/pulse/net-core-tdd-visual-studio-code-mac-osx-vinit-patankar-pmp/

This article is good for you to start on test driven development.

So now lets look into the Integration test I have created for CRUD operation for Sqlite Provider using XUnit testing framework.

## Integration Test for Orders
To test SQLite functionality, I have created an Integration test with the name `TestSqliteProvider.cs` that will verify CRUD functionality for me.

``` C#
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
            // Need to ensure the database is created and schema is generated.
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
```

In the above code snippet, I have followed 3 steps(Arrange, Act and Assert) which are depending on the way you write your tests. Let me explain all the three above:
Arrange: We define and initiate all the requirements that we will use at the time of execution.
Act: After Arranging everything we need to run the actual method for gathering the results from the method call
Assert: After gathering results we validate them with the help of Assert methods. For Example: Assert.Equal(), Assert.Empty() etc..

[Previous Topic][1] <br>                                [Next Topic][2]

[1]: SQLITESETUP.md
[2]: SettingUpApplication.md
