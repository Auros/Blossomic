using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Models
{
    public class BeatmapInfo
    {
        [JsonPropertyName("_version")]
        public string Version { get; set; } = "2.2.0";

        [JsonPropertyName("_songName")]
        public string SongName { get; set; } = null!;

        [JsonPropertyName("_songSubName")]
        public string SongSubName { get; set; } = null!;

        [JsonPropertyName("_songAuthorName")]
        public string SongAuthorName { get; set; } = null!;

        [JsonPropertyName("_levelAuthorName")]
        public string LevelAuthorName { get; set; } = null!;

        [JsonPropertyName("_beatsPerMinute")]
        public float BPM { get; set; }

        [JsonPropertyName("_shuffle")]
        public float Shuffle { get; set; }

        [JsonPropertyName("_shufflePeriod")]
        public float ShufflePeriod { get; set; }

        [JsonPropertyName("_previewStartTime")]
        public float PreviewStartTime { get; set; }

        [JsonPropertyName("_previewDuration")]
        public float PreviewDuration { get; set; }

        [JsonPropertyName("_coverImageFilename")]
        public string CoverImageFileName { get; set; } = null!;

        [JsonPropertyName("_environmentName")]
        public string EnvironmentName { get; set; } = null!;

        [JsonPropertyName("_songTimeOffset")]
        public float SongTimeOffset { get; set; }

        [JsonPropertyName("_customData"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public JsonElement CustomData { get; set; }

        [JsonPropertyName("_difficultyBeatmapSets")]
        public List<BeatmapSet> BeatmapSets { get; set; } = new();

        [JsonPropertyName("_songFilename")]
        public string SongFileName { get; set; } = null!;

        [JsonPropertyName("_allDirectionsEnvironmentName"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? AllDirectionsEnvironmentName { get; set; } = null!;
    }
}