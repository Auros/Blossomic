using Blossomic.Noodle;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Converters
{
    public class LineArrayConverter : JsonConverter<Line>
    {
        public override Line? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (JsonSerializer.Deserialize(ref reader, typeof(object[]), options) is not object[] deserialized)
                throw new NullReferenceException(nameof(deserialized));

            return new Line
            {
                X = ((JsonElement)deserialized[0]).GetSingle(),
                Y = ((JsonElement)deserialized[1]).GetSingle(),
            };
        }

        public override void Write(Utf8JsonWriter writer, Line value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, new object[] { value.X, value.Y }, typeof(object[]), options);
        }
    }
}