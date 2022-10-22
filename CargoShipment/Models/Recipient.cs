using CargoShipment.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CargoShipment.Models
{
    public class Receipient
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

    }
}