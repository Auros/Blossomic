using Blossomic.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Converters
{
    internal class BeatmapDifficultyCustomDataConverter : JsonConverter<BeatmapDifficultyCustomData>
    {
        public override BeatmapDifficultyCustomData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var beatmapData = JsonSerializer.Deserialize<BeatmapDifficultyCustomData>(ref reader, options);
            beatmapData?.Load();
            return beatmapData;
        }

        public override void Write(Utf8JsonWriter writer, BeatmapDifficultyCustomData value, JsonSerializerOptions options)
        {
            value.Save();
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}