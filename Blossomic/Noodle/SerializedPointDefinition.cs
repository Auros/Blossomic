using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class SerializedPointDefinition
    {
        [JsonPropertyName("_name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("_bType")]
        public string? BType { get; set; } = null!;

        [JsonPropertyName("_points")]
        public List<object[]> Points { get; set; } = new();
    }
}