using System.Text.Json.Serialization;

namespace CampusLostFound.Api.Models
{
    public class FoundItem
    {
        [JsonIgnore]
        public int FoundItemId { get; set; }

        [JsonPropertyName("id")]
        public int Id => FoundItemId;

        public string ItemName { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
