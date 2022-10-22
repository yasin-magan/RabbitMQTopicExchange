using MiddleWareMessenger.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiddleWareMessenger.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        [Required]
        public string SKU { get; set; } = string.Empty;
        [Required]
        public string RegionAddress { get; set; } = string.Empty;

    }
}