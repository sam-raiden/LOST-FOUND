using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CampusLostFound.Api.Models
{
    public class LostItem
    {
        [Key]
        [JsonIgnore]
        public int LostItemId { get; set; }

        // Exposed to frontend as "id"
        [JsonPropertyName("id")]
        public int Id => LostItemId;

        [Required]
        public string ItemName { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string Contact { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.UtcNow;

        // 🔥 IMPORTANT: NOT REQUIRED + DEFAULT VALUE
        public string Status { get; set; } = "Pending";
    }
}
