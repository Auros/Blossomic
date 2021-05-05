using Blossomic.Noodle;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Converters
{
    internal class EventTypeConverter : JsonConverter<EventType>
    {
        public override EventType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (Enum.TryParse(reader.GetString(), out EventType result))
                return result;
            throw new InvalidCastException(nameof(EventType));
        }

        public override void Write(Utf8JsonWriter writer, EventType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}