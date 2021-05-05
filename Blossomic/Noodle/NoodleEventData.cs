using Blossomic.Converters;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class NoodleEventData
    {
        [JsonPropertyName("_track")]
        public string Track { get; set; } = null!;

        [JsonPropertyName("_duration")]
        public float Duration { get; set; }

        [JsonConverter(typeof(FloatPointConverter))]
        [JsonPropertyName("_time"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FloatPointDefinition? Time { get; set; }
    }
}