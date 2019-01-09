using System;
using System.ComponentModel.DataAnnotations;

namespace SignalR_GoogleMap_Web.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage="Please enter order title.")]
        public string OrderTitle { get; set; }
        [Required(ErrorMessage="Please enter longitude.")]
        public double Longitude { get; set; }
        [Required(ErrorMessage="Please enter latitude.")]
        public double Latitude { get; set; }
        [Required(ErrorMessage="Please enter status.")]
        public string Status { get; set; }
    }
}