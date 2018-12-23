using Microsoft.EntityFrameworkCore;
using SignalR_GoogleMap_Sqlite.Model;

namespace SignalR_GoogleMap_Sqlite.Repository.Context
{
    public class SqliteContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
public SqliteContext(DbContextOptions<SqliteContext> contextOptions) :base (contextOptions)
{
    
}
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite("Data Source=Orders.db");
        // }
    }
}