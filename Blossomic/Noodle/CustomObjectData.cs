using Blossomic.Converters;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class CustomObjectData
    {
        [JsonExtensionData]
        public Dictionary<string, object> ExtensionData { get; set; } = new();

        [JsonPropertyName("_track"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Track { get; set; } = null!;

        [JsonConverter(typeof(LineArrayConverter))]
        [JsonPropertyName("_position"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Line? Position { get; set; }

        [JsonConverter(typeof(VectorArrayConverter))]
        [JsonPropertyName("_rotation"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Vector? Rotation { get; set; }

        [JsonConverter(typeof(VectorArrayConverter))]
        [JsonPropertyName("_localRotation"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Vector? LocalRotation { get; set; }

        [JsonPropertyName("_noteJumpMovementSpeed"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? NJS { get; set; }

        [JsonPropertyName("_noteJumpStartBeatOffset"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? StartBeatOffset { get; set; }

        [JsonPropertyName("_fake"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Fake { get; set; }

        [JsonPropertyName("_interactable"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Interactable { get; set; }
    }
}