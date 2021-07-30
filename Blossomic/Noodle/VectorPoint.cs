using Blossomic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blossomic.Noodle
{
    public class VectorPointDefinition : PointDefinition<Vector>
    {
        public VectorPointDefinition()
        {

        }

        public VectorPointDefinition(List<Point<Vector>> points)
        {
            Points = points;
        }
    }

    public class Vector
    {
        public Vector()
        {

        }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float? X { get; set; }
        public float? Y { get; set; }
        public float? Z { get; set; }
    }

    public class VectorPoint : Point<Vector>
    {
        public VectorPoint()
        {

        }

        public VectorPoint(Vector vector)
        {
            Value = vector;
        }

        public VectorPoint(Vector vector, float time)
        {
            Value = vector;
            Time = time;
        }

        public VectorPoint(Vector vector, float time, EaseType easing)
        {
            Value = vector;
            Time = time;
            Easing = easing;
        }

        public VectorPoint(Vector vector, float time, EaseType easing, SplineType spline)
        {
            Value = vector;
            Time = time;
            Easing = easing;
            Spline = spline;
        }

        internal override void Load(IEnumerable<object> pointArray)
        {
            try
            {
                if (pointArray.ElementAt(0) is float x)
                    Value.X = x;
                else
                    throw new InvalidCastException();

                if (pointArray.ElementAt(1) is float y)
                    Value.Y = y;
                else
                    throw new InvalidCastException();

                if (pointArray.ElementAt(2) is float z)
                    Value.Z = z;
                else
                    throw new InvalidCastException();

                LoadDefaults(ref pointArray, 3);
            }
            catch (Exception e) { throw new InvalidPointDataException(nameof(VectorPoint), e); }
        }

        internal override IEnumerable<object> Save()
        {
            object[] values = new object[6];
            values[0] = Value.X!;
            values[1] = Value.Y!;
            values[2] = Value.Z!;
            SaveDefaultsAndRemoveEmpties(ref values, 3);
            return values;
        }
    }
}