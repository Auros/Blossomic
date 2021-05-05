using Blossomic.Noodle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Converters
{
    internal abstract class PointConverter<T, TPointType, TPointValue> : JsonConverter<T> where T : PointDefinition<TPointValue> where TPointType : Point<TPointValue>
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string pointName = reader.GetString()!;
                var partialPointDef = Activator.CreateInstance<T>();
                partialPointDef.Name = pointName;
                return partialPointDef;
            }

            if (JsonSerializer.Deserialize(ref reader, typeof(object[][]), options) is not object[][] deserializedPoints)
                throw new NullReferenceException(nameof(deserializedPoints));

            var pointDef = Activator.CreateInstance<T>();
            if (pointDef.Points is null)
                pointDef.Points = new();
            foreach (var pt in deserializedPoints)
            {
                var point = Activator.CreateInstance<TPointType>();
                point.Load(PointConverter<T, TPointType, TPointValue>.Process(pt.Cast<JsonElement>()));
                pointDef.Points.Add(point);
            }
            return pointDef;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Points?.SelectMany(v => v.Save()) ?? null, typeof(object[][]), options);
        }

        private static IEnumerable<object> Process(IEnumerable<JsonElement> elements)
        {
            object[] objects = new object[elements.Count()];
            for (int i = 0; i < elements.Count(); i++)
            {
                var element = elements.ElementAt(i);
                switch (elements.ElementAt(i).ValueKind)
                {
                    case JsonValueKind.Number:
                        objects[i] = element.GetSingle();
                        break;
                    case JsonValueKind.String:
                        objects[i] = element.GetString()!;
                        break;
                    case JsonValueKind.Undefined:
                    case JsonValueKind.Object:
                    case JsonValueKind.Array:
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                    case JsonValueKind.Null:
                        throw new Exception("SHE MADE BEEEAAAANS WHAT THE FUCK (could not find point type)");
                }
            }
            return objects;
        }
    }
}