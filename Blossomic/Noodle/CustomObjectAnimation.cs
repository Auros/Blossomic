using Blossomic.Converters;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class CustomObjectAnimation
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

        [JsonConverter(typeof(FloatPointConverter))]
        [JsonPropertyName("_time"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FloatPointDefinition? Time { get; set; }

        [JsonConverter(typeof(VectorPointConverter))]
        [JsonPropertyName("_definitePosition"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VectorPointDefinition? DefinitePosition { get; set; }
    }
}