using System.Linq;
using System.Collections.Generic;
using SignalR_GoogleMap_Sqlite.Model;
using SignalR_GoogleMap_Sqlite.Repository.Context;

namespace SignalR_GoogleMap_Sqlite.Repository
{
    public interface ISqliteProvider
    {
        List<Order> GetAll();
        Order Insert(Order entity);
        Order Update(Order entity);
        Order Remove(Order entity);
    }
}