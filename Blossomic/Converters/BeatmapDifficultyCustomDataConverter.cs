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
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, BeatmapDifficultyCustomData value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}