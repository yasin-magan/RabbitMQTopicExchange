using CargoShipment.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CargoShipment.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public string RegionAddress { get; set; } = string.Empty;

    }
}