using System;
using System.Collections.Generic;
using System.Linq;

namespace Blossomic.Noodle
{
    public abstract class Point<T>
    {
        private const string ease = "ease";
        private const string spline = "spline";

        private T? _value;
        public T Value
        {
            get
            {
                if (_value is null)
                {
                    _value = Activator.CreateInstance<T>();
                }
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public float Time { get; set; }
        public EaseType Easing { get; set; }
        public SplineType Spline { get; set; }

        public abstract void Load(IEnumerable<object> pointArray);
        public abstract IEnumerable<object> Save();
    
        protected void LoadDefaults(ref IEnumerable<object> pointArray, int timeIndex)
        {
            if (pointArray.ElementAt(timeIndex++) is float time)
                Time = time;
            else
                throw new InvalidCastException();

            if (pointArray.Count() > timeIndex)
                if (pointArray.ElementAt(timeIndex++) is string text)
                    ProcessOptionalString(text);
            if (pointArray.Count() > timeIndex)
                if (pointArray.ElementAt(timeIndex++) is string text)
                    ProcessOptionalString(text);
        }

        protected void SaveDefaultsAndRemoveEmpties(ref object[] pointArray, int timeIndex)
        {
            pointArray[timeIndex++] = Time;

            if (Easing != EaseType.None)
                pointArray[timeIndex++] = $"{ease}{Easing}";
            if (Spline != SplineType.None)
                pointArray[timeIndex++] = $"{spline}{Spline}";

            pointArray = pointArray.Where(pv => pv is not null).ToArray();
        }

        private void ProcessOptionalString(string text)
        {
            if (text.StartsWith(ease))
                Easing = Enum.Parse<EaseType>(text.Remove(0, ease.Length));
            else if (text.StartsWith(spline))
                Spline = Enum.Parse<SplineType>(text.Remove(0, spline.Length));
        }
    }
}