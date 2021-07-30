using Blossomic.Noodle;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Blossomic.Models
{
    public class BeatmapDifficultyCustomData
    {
        [JsonExtensionData]
        public Dictionary<string, object> ExtensionData { get; set; } = new();

        [JsonPropertyName("_pointDefinitions")]
        public List<SerializedPointDefinition> SerializedPointDefinitions { get; set; } = new();

        [JsonPropertyName("_customEvents")]
        public List<CustomEvent> CustomEvents { get; set; } = new();

        [JsonIgnore]
        public List<VectorPointDefinition> VectorPointDefinitions { get; set; } = new();

        [JsonIgnore]
        public List<ColorPointDefinition> ColorPointDefinitions { get; set; } = new();

        [JsonIgnore]
        public List<FloatPointDefinition> FloatPointDefinitions { get; set; } = new();

        [JsonIgnore]
        public List<BoolPointDefinition> BoolPointDefinitions { get; set; } = new();

        [JsonIgnore]
        public List<NoodleEvent<PlayerNoodleEventData>> PlayerEvents { get; set; } = new();

        [JsonIgnore]
        public List<NoodleEvent<ParentNoodleEventData>> ParentEvents { get; set; } = new();

        [JsonIgnore]
        public List<NoodleEvent<TrackNoodleEventData>> TrackEvents { get; set; } = new();

        [JsonIgnore]
        public List<NoodleEvent<PathNoodleEventData>> PathEvents { get; set; } = new();

        public void Load()
        {
            VectorPointDefinitions.Clear();
            ColorPointDefinitions.Clear();
            FloatPointDefinitions.Clear();
            BoolPointDefinitions.Clear();

            PlayerEvents.Clear();
            ParentEvents.Clear();
            TrackEvents.Clear();
            PathEvents.Clear();

            foreach (var serializedPointDef in SerializedPointDefinitions)
            {
                if (serializedPointDef.BType == "Vector")
                    VectorPointDefinitions.Add(new VectorPointDefinition { Name = serializedPointDef.Name, Points = serializedPointDef.Points.Select(p => PointFactory<VectorPoint, Vector>(p)).ToList() });
               else if (serializedPointDef.BType == "Color")
                    ColorPointDefinitions.Add(new ColorPointDefinition { Name = serializedPointDef.Name, Points = serializedPointDef.Points.Select(p => PointFactory<ColorPoint, Color>(p)).ToList() });
                else if (serializedPointDef.BType == "Float")
                    FloatPointDefinitions.Add(new FloatPointDefinition { Name = serializedPointDef.Name, Points = serializedPointDef.Points.Select(p => PointFactory<FloatPoint, float>(p)).ToList() });
                else if (serializedPointDef.BType == "Bool")
                    BoolPointDefinitions.Add(new BoolPointDefinition { Name = serializedPointDef.Name, Points = serializedPointDef.Points.Select(p => PointFactory<BoolPoint, bool>(p)).ToList() });
            }

            foreach (var serializedEvent in CustomEvents)
            {
                if (serializedEvent.Type == EventType.AssignPlayerToTrack)
                    PlayerEvents.Add(new NoodleEvent<PlayerNoodleEventData> { Data = (serializedEvent.Data as PlayerNoodleEventData)!, Time = serializedEvent.Time });
                else if (serializedEvent.Type == EventType.AssignTrackParent)
                    ParentEvents.Add(new NoodleEvent<ParentNoodleEventData> { Data = (serializedEvent.Data as ParentNoodleEventData)!, Time = serializedEvent.Time });
                else if (serializedEvent.Type == EventType.AnimateTrack)
                    TrackEvents.Add(new NoodleEvent<TrackNoodleEventData> { Data = (serializedEvent.Data as TrackNoodleEventData)!, Time = serializedEvent.Time });
                else if (serializedEvent.Type == EventType.AssignPathAnimation)
                    PathEvents.Add(new NoodleEvent<PathNoodleEventData> { Data = (serializedEvent.Data as PathNoodleEventData)!, Time = serializedEvent.Time });
            }
        }

        public void Save()
        {
            CustomEvents.Clear();
            SerializedPointDefinitions.Clear();

            foreach (var vectorEvent in VectorPointDefinitions)
                SerializedPointDefinitions.Add(new SerializedPointDefinition { BType = "Vector", Name = vectorEvent.Name!, Points = vectorEvent.Points?.Select(p => p.Save().ToArray()).ToList() ?? new List<object[]>() });
            foreach (var colorEvent in ColorPointDefinitions)
                SerializedPointDefinitions.Add(new SerializedPointDefinition { BType = "Color", Name = colorEvent.Name!, Points = colorEvent.Points?.Select(p => p.Save().ToArray()).ToList() ?? new List<object[]>() });
            foreach (var floatEvent in FloatPointDefinitions)
                SerializedPointDefinitions.Add(new SerializedPointDefinition { BType = "Float", Name = floatEvent.Name!, Points = floatEvent.Points?.Select(p => p.Save().ToArray()).ToList() ?? new List<object[]>() });
            foreach (var boolEvent in BoolPointDefinitions)
                SerializedPointDefinitions.Add(new SerializedPointDefinition { BType = "Bool", Name = boolEvent.Name!, Points = boolEvent.Points?.Select(p => p.Save().ToArray()).ToList() ?? new List<object[]>() });

            foreach (var playerEvent in PlayerEvents)
                CustomEvents.Add(new CustomEvent { Data = playerEvent.Data, Time = playerEvent.Time, Type = EventType.AssignPlayerToTrack });
            foreach (var parentEvent in ParentEvents)
                CustomEvents.Add(new CustomEvent { Data = parentEvent.Data, Time = parentEvent.Time, Type = EventType.AssignTrackParent });
            foreach (var trackEvent in TrackEvents)
                CustomEvents.Add(new CustomEvent { Data = trackEvent.Data, Time = trackEvent.Time, Type = EventType.AnimateTrack });
            foreach (var pathEvent in PathEvents)
                CustomEvents.Add(new CustomEvent { Data = pathEvent.Data, Time = pathEvent.Time, Type = EventType.AssignPathAnimation });
        }

        private static Point<TPointType> PointFactory<T, TPointType>(object[] objects) where T : Point<TPointType>, new()
        {
            T t = new();
            t.Load(objects);
            return t;
        }

    }
}