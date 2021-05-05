using Blossomic.Converters;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public abstract class BasicNoodleEventData : BaseNoodleEventData
    {
        [JsonPropertyName("_track")]
        public string Track { get; set; } = null!;

        [JsonConverter(typeof(VectorPointConverter))]
        [JsonPropertyName("_scale"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VectorPointDefinition? Scale { get; set; }

        [JsonConverter(typeof(FloatPointConverter))]
        [JsonPropertyName("_dissolve"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FloatPointDefinition? Dissolve { get; set; }

        [JsonConverter(typeof(FloatPointConverter))]
        [JsonPropertyName("_dissolveArrow"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FloatPointDefinition? DissolveArrow { get; set; }

        [JsonConverter(typeof(ColorPointConverter))]
        [JsonPropertyName("_color"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ColorPointDefinition? Color { get; set; }

        [JsonConverter(typeof(BoolPointConverter))]
        [JsonPropertyName("_interactable"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BoolPointDefinition? Interactable { get; set; }
    }
}