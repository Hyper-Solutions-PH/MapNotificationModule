using System.Linq;
using System.Collections.Generic;
using SignalR_GoogleMap_Sqlite.Model;
using SignalR_GoogleMap_Sqlite.Repository.Context;

namespace SignalR_GoogleMap_Sqlite.Repository
{
    public class SqliteProvider
    {
        private readonly SqliteContext _context;
        public SqliteProvider(SqliteContext context)
        {
            _context=context;
        }

        public List<Order> GetAll(){
            var query = _context.Orders.ToList();
            return query;
        }

        public Order Insert(Order entity){
            _context.Orders.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Order Update(Order entity){
            var exits=_context.Orders.Find(entity.Id);
            if (exits != null)
            {
            _context.Entry(exits).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            }
            return entity;
        }

        public Order Remove(Order entity){
            _context.Orders.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

    }
}