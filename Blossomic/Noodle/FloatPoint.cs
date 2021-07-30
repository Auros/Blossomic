using Blossomic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blossomic.Noodle
{
    public class FloatPointDefinition : PointDefinition<float>
    {
        public FloatPointDefinition()
        {

        }

        public FloatPointDefinition(List<Point<float>> points)
        {
            Points = points;
        }
    }

    public class FloatPoint : Point<float>
    {
        public FloatPoint()
        {

        }

        public FloatPoint(float value)
        {
            Value = value;
        }

        public FloatPoint(float value, float time)
        {
            Value = value;
            Time = time;
        }

        public FloatPoint(float value, float time, EaseType easing)
        {
            Value = value;
            Time = time;
            Easing = easing;
        }

        public FloatPoint(float value, float time, EaseType easing, SplineType spline)
        {
            Value = value;
            Time = time;
            Easing = easing;
            Spline = spline;
        }

        internal override void Load(IEnumerable<object> pointArray)
        {
            try
            {
                if (pointArray.ElementAt(0) is float value)
                    Value = value;
                else
                    throw new InvalidCastException();

                LoadDefaults(ref pointArray, 1);
            }
            catch (Exception e) { throw new InvalidPointDataException(nameof(FloatPoint), e); }
        }

        internal override IEnumerable<object> Save()
        {
            object[] values = new object[4];
            values[0] = Value;
            SaveDefaultsAndRemoveEmpties(ref values, 1);
            return values;
        }
    }
}