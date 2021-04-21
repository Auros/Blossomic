using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blossomic.Models
{
    public class BeatmapSet
    {
        [JsonPropertyName("_beatmapCharacteristicName")]
        public string CharacteristicName { get; set; } = null!;

        [JsonPropertyName("_difficultyBeatmaps")]
        public List<DifficultyBeatmap> Beatmaps { get; set; } = new();
    }
}