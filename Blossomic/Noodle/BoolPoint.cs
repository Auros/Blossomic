using Blossomic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blossomic.Noodle
{
    public class BoolPointDefinition : PointDefinition<bool>
    {
        public BoolPointDefinition()
        {

        }

        public BoolPointDefinition(List<Point<bool>> points)
        {
            Points = points;
        }
    }

    public class BoolPoint : Point<bool>
    {
        public BoolPoint()
        {

        }

        public BoolPoint(bool value)
        {
            Value = value;
        }

        public BoolPoint(bool value, float time)
        {
            Value = value;
            Time = time;
        }

        public BoolPoint(bool value, float time, EaseType easing)
        {
            Value = value;
            Time = time;
            Easing = easing;
        }

        public BoolPoint(bool value, float time, EaseType easing, SplineType spline)
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
                    Value = value >= 1f;
                else
                    throw new InvalidCastException();

                LoadDefaults(ref pointArray, 1);
            }
            catch (Exception e) { throw new InvalidPointDataException(nameof(BoolPoint), e); }
        }

        internal override IEnumerable<object> Save()
        {
            object[] values = new object[4];
            values[0] = Value ? 1 : 0;
            SaveDefaultsAndRemoveEmpties(ref values, 1);
            return values;
        }
    }
}
