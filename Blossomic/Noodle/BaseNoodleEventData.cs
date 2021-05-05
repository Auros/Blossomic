using Blossomic.Converters;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public abstract class BaseNoodleEventData
    {
        [JsonConverter(typeof(VectorPointConverter))]
        [JsonPropertyName("_position"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VectorPointDefinition? Position { get; set; }

        [JsonConverter(typeof(VectorPointConverter))]
        [JsonPropertyName("_rotation"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VectorPointDefinition? Rotation { get; set; }

        [JsonConverter(typeof(VectorPointConverter))]
        [JsonPropertyName("_localRotation"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VectorPointDefinition? LocalRotation { get; set; }
    }
}