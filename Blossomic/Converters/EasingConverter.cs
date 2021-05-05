using Blossomic.Noodle;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Converters
{
    internal class EasingConverter : JsonConverter<EaseType>
    {
        private const string ease = "ease";

        public override EaseType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (Enum.TryParse(reader.GetString()!.Remove(0, ease.Length), out EaseType result))
                return result;
            throw new InvalidCastException(nameof(EaseType));
        }

        public override void Write(Utf8JsonWriter writer, EaseType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{ease}{value}");
        }
    }
}