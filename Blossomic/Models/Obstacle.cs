using Blossomic.Noodle;
using System.Text.Json.Serialization;

namespace Blossomic.Models
{
    public class Obstacle
    {
        [JsonPropertyName("_time")]
        public float Time { get; set; }

        [JsonPropertyName("_lineIndex")]
        public int LineIndex { get; set; }

        [JsonPropertyName("_type")]
        public ObstacleType Type { get; set; }

        [JsonPropertyName("_duration")]
        public float Duration { get; set; }

        [JsonPropertyName("_width")]
        public int Width { get; set; }

        [JsonPropertyName("_customData"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomObstacleData? CustomData { get; set; }
    }
}