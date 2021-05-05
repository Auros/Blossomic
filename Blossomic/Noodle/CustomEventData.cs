using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class CustomEventData
    {
        [JsonIgnore]
        internal List<JsonProperty> UnhandledProperties { get; set; } = new();

        [JsonPropertyName("_rotation"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Rotation { get; set; }
    }
}