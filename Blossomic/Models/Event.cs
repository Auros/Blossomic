using Blossomic.Noodle;
using System.Text.Json.Serialization;

namespace Blossomic.Models
{
    public class Event
    {
        [JsonPropertyName("_time")]
        public float Time { get; set; }

        [JsonPropertyName("_type")]
        public BeatmapEventType Type { get; set; }

        [JsonPropertyName("_value")]
        public int Value { get; set; }

        [JsonPropertyName("_customData"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomEventData? CustomData { get; set; }
    }
}