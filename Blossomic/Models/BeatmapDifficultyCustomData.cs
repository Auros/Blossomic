using Blossomic.Noodle;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Models
{
    public class BeatmapDifficultyCustomData
    {
        [JsonExtensionData]
        public Dictionary<string, object> ExtensionData { get; set; } = new();

        [JsonPropertyName("_pointDefinitions")]
        public List<SerializedPointDefinition> SerializedPointDefinitions { get; set; } = new();

        [JsonPropertyName("_customEvents")]
        public List<CustomEvent> CustomEvents { get; set; } = new();

        [JsonIgnore]
        public List<VectorPointDefinition> VectorPointDefinitions { get; set; } = new();

        [JsonIgnore]
        public List<ColorPointDefinition> ColorPointDefinitions { get; set; } = new();

        [JsonIgnore]
        public List<FloatPointDefinition> FloatPointDefinitions { get; set; } = new();

        [JsonIgnore]
        public List<BoolPointDefinition> BoolPointDefinitions { get; set; } = new();

        [JsonIgnore]
        public List<NoodleEvent<PlayerNoodleEventData>> PlayerEvents { get; set; } = new();

        [JsonIgnore]
        public List<NoodleEvent<ParentNoodleEventData>> ParentEvents { get; set; } = new();

        [JsonIgnore]
        public List<NoodleEvent<TrackNoodleEventData>> TrackEvents { get; set; } = new();

        [JsonIgnore]
        public List<NoodleEvent<PathNoodleEventData>> PathEvents { get; set; } = new();
    }
}