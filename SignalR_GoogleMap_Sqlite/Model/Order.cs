using System.ComponentModel.DataAnnotations;

namespace SignalR_GoogleMap_Sqlite.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string OrderTitle { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Status { get; set; }
    }
}