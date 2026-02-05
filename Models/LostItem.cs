using System.Text.Json.Serialization;

namespace CampusLostFound.Api.Models
{
    public class LostItem
    {
        [JsonIgnore]
        public int LostItemId { get; set; }

        // 👇 THIS IS WHAT FRONTEND NEEDS
        [JsonPropertyName("id")]
        public int Id => LostItemId;

        public string ItemName { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
