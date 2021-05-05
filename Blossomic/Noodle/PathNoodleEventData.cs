using Blossomic.Converters;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class PathNoodleEventData : BasicNoodleEventData
    {
        [JsonPropertyName("_duration"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Duration { get; set; }

        [JsonConverter(typeof(EasingConverter))]
        [JsonPropertyName("_easing"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EaseType? Easing { get; set; }

        [JsonConverter(typeof(VectorPointConverter))]
        [JsonPropertyName("_definitePosition"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VectorPointDefinition? DefinitePosition { get; set; }
    }
}