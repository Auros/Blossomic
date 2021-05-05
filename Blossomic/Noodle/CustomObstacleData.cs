using Blossomic.Converters;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class CustomObstacleData : CustomObjectData
    {
        [JsonConverter(typeof(VectorArrayConverter))]
        [JsonPropertyName("_scale"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Vector? Scale { get; set; }
    }
}