using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Models
{
    public class Note
    {
        [JsonPropertyName("_time")]
        public float Time { get; set; }

        [JsonPropertyName("_lineIndex")]
        public int LineIndex { get; set; }

        [JsonPropertyName("_lineLayer")]
        public NoteLineLayer LineLayer { get; set; }

        [JsonPropertyName("_type")]
        public NoteType Type { get; set; }

        [JsonPropertyName("_cutDirection")]
        public NoteCutDirection CutDirection { get; set; }

        [JsonPropertyName("_customData"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public JsonElement CustomData { get; set; }
    }
}