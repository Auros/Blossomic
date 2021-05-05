using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class PointDefinition<TPointType>
    {
        [JsonPropertyName("_name")]
        public string? Name { get; set; }

        [JsonPropertyName("_points")]
        public List<Point<TPointType>>? Points { get; set; } = null;
    }
}