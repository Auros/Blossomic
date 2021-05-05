using Blossomic.Noodle;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Converters
{
    public class ColorArrayConverter : JsonConverter<Color>
    {
        public override Color? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (JsonSerializer.Deserialize(ref reader, typeof(object[]), options) is not object[] deserialized)
                throw new NullReferenceException(nameof(deserialized));

            return new Color
            {
                R = (float)deserialized[0],
                G = (float)deserialized[1],
                B = (float)deserialized[2],
                A = (float)deserialized[3]
            };
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, new object[] { value.R, value.G, value.B, value.A }, typeof(object[]), options);
        }
    }
}