using Microsoft.EntityFrameworkCore;
using SignalR_GoogleMap_Sqlite.Repository.Context;

namespace SignalR_GoogleMap_Tests.Abstract
{
    public abstract class TestBase
    {
        private bool useSqlite;

        // public SqliteContext GetDbContext()
        // {
        //     DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        //     if(useSqlite){
        //         // use Sqlite
        //         builder.UseSqlite("Data Source=:memory");
        //     }
        // }
    }
}