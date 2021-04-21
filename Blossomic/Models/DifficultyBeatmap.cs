using Blossomic.Converters;
using System.Text.Json.Serialization;

namespace Blossomic.Models
{
    public class DifficultyBeatmap
    {
        [JsonPropertyName("_difficulty")]
        [JsonConverter(typeof(DifficultyConverter))]
        public Difficulty Difficulty { get; set; }

        [JsonPropertyName("_difficultyRank")]
        public int DifficultyRank { get; set; }

        [JsonPropertyName("_beatmapFilename")]
        public string BeatmapFileName { get; set; } = null!;

        [JsonPropertyName("_noteJumpMovementSpeed")]
        public float NJS { get; set; }

        [JsonPropertyName("_noteJumpStartBeatOffset")]
        public float Offset { get; set; }
    }
}