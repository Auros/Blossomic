using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class ParentNoodleEventData : BaseNoodleEventData
    {
        [JsonPropertyName("_childrenTracks")]
        public List<string> ChildTracks { get; set; } = new();

        [JsonPropertyName("_parentTrack")]
        public string ParentTrack { get; set; } = null!;
    }
}