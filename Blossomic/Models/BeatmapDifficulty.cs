using Blossomic.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blossomic.Models
{
    public class BeatmapDifficulty
    {
        [JsonPropertyName("_version")]
        public string Version { get; set; } = null!;

        [JsonPropertyName("_events")]
        public List<Event> Events { get; set; } = new();

        [JsonPropertyName("_notes")]
        public List<Note> Notes { get; set; } = new();

        [JsonPropertyName("_obstacles")]
        public List<Obstacle> Obstacles { get; set; } = new();

        [JsonConverter(typeof(BeatmapDifficultyCustomDataConverter))]
        [JsonPropertyName("_customData"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public BeatmapDifficultyCustomData? CustomData { get; set; }
    }
}