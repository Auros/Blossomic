using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class PlayerNoodleEventData : BaseNoodleEventData
    {
        [JsonPropertyName("_track")]
        public string Track { get; set; } = null!;
    }
}