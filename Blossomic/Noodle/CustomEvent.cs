using Blossomic.Converters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blossomic.Noodle
{
    public class CustomEvent
    {
        [JsonPropertyName("_time")]
        public float Time { get; set; }
        
        [JsonPropertyName("_type")]
        [JsonConverter(typeof(EventTypeConverter))]
        public EventType Type { get; set; }

        [JsonPropertyName("_data")]
        public JsonElement SerializedData { get; set; }

        private BaseNoodleEventData _data = null!;
        [JsonIgnore]
        public BaseNoodleEventData Data
        {
            get
            {
                if (_data == null)
                {
                    if (Type == EventType.AnimateTrack)
                        _data = JsonSerializer.Deserialize<TrackNoodleEventData>(SerializedData.GetRawText())!;
                    else if (Type == EventType.AssignPathAnimation)
                        _data = JsonSerializer.Deserialize<PathNoodleEventData>(SerializedData.GetRawText())!;
                    else if (Type == EventType.AssignPlayerToTrack)
                        _data = JsonSerializer.Deserialize<PlayerNoodleEventData>(SerializedData.GetRawText())!;
                    else if (Type == EventType.AssignTrackParent)
                        _data = JsonSerializer.Deserialize<ParentNoodleEventData>(SerializedData.GetRawText())!;
                }
                return _data!;
            }
            set
            {
                if (_data != null)
                    SerializedData = JsonSerializer.Deserialize<JsonElement>(JsonSerializer.Serialize(_data, _data.GetType()));
            }
        }
    }
}