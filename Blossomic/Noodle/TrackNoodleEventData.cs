using Blossomic.Converters;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class TrackNoodleEventData : BasicNoodleEventData
    {
        [JsonPropertyName("_duration"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Duration { get; set; }

        [JsonConverter(typeof(EasingConverter))]
        [JsonPropertyName("_easing"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EaseType? Easing { get; set; }
        
        [JsonConverter(typeof(FloatPointConverter))]
        [JsonPropertyName("_time"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FloatPointDefinition? Time { get; set; }
    }
}