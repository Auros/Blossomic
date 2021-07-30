using Blossomic.Converters;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class CustomNoteData : CustomObjectData
    {
        [JsonPropertyName("_cutDirection"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? CutDirection { get; set; }

        [JsonConverter(typeof(FlipArrayConverter))]
        [JsonPropertyName("_flip"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Flip? Flip { get; set; }

        [JsonPropertyName("_disableNoteGravity"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DisableNoteGravity { get; set; }

        [JsonPropertyName("_disableNoteLook"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DisableNoteLook { get; set; }

        [JsonPropertyName("_disableSpawnEffect"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DisableSpawnEffect { get; set; }
    }
}