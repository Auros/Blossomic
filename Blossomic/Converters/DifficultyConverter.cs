using Blossomic.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Converters
{
    internal class DifficultyConverter : JsonConverter<Difficulty>
    {
        public override Difficulty Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (Enum.TryParse(reader.GetString(), out Difficulty result))
                return result;
            throw new InvalidCastException(nameof(Difficulty));
        }

        public override void Write(Utf8JsonWriter writer, Difficulty value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}