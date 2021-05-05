using Blossomic.Noodle;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Converters
{
    public class FlipArrayConverter : JsonConverter<Flip>
    {
        public override Flip? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (JsonSerializer.Deserialize(ref reader, typeof(object[]), options) is not object[] deserialized)
                throw new NullReferenceException(nameof(deserialized));

            return new Flip
            {
                LineIndex = ((JsonElement)deserialized[0]).GetSingle(),
                Jump = ((JsonElement)deserialized[1]).GetSingle(),
            };
        }

        public override void Write(Utf8JsonWriter writer, Flip value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, new object[] { value.LineIndex, value.Jump }, typeof(object[]), options);
        }
    }
}