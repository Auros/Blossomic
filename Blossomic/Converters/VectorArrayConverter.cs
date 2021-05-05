using Blossomic.Noodle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Converters
{
    public class VectorArrayConverter : JsonConverter<Vector>
    {
        public override Vector? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            List<float?> deserialized;
            if (reader.TokenType == JsonTokenType.Number)
                deserialized = new List<float?>() { 0f, reader.GetSingle(), 0f };
            else
            {
                var seri = JsonSerializer.Deserialize(ref reader, typeof(object[]), options);
                if (seri is not object[] des)
                    throw new NullReferenceException(nameof(deserialized));

                deserialized = new List<float?>();
                float? v1 = des.Length >= 1 ? ((JsonElement)des[0]).GetSingle() : null;
                float? v2 = des.Length >= 2 ? ((JsonElement)des[1]).GetSingle() : null;
                float? v3 = des.Length >= 3 ? ((JsonElement)des[2]).GetSingle() : null;
                deserialized.Add(v1);
                deserialized.Add(v2);
                deserialized.Add(v3);
            }

            return new Vector
            {
                X = deserialized[0],
                Y = deserialized[1],
                Z = deserialized[2],
            };
        }

        public override void Write(Utf8JsonWriter writer, Vector value, JsonSerializerOptions options)
        {
            var toSerialize = new List<float?>
            {
                value.X,
                value.Y,
                value.Z
            };

            JsonSerializer.Serialize(writer, toSerialize.Where(u => u.HasValue).Cast<object>().ToArray(), typeof(object[]), options);
        }
    }
}