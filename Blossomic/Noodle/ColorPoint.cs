using Blossomic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blossomic.Noodle
{
    public class ColorPointDefinition : PointDefinition<Color>
    {
        public ColorPointDefinition()
        {

        }

        public ColorPointDefinition(List<Point<Color>> points)
        {
            Points = points;
        }
    }

    public class Color
    {
        public Color()
        {

        }

        public Color (float rgb)
        {
            R = G = B = rgb;
        }

        public Color (float rgb, float a = 1f)
        {
            R = G = B = rgb;
            A = a;
        }

        public Color(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; } = 1f;
    }

    public class ColorPoint : Point<Color>
    {
        public ColorPoint()
        {

        }

        public ColorPoint(Color color)
        {
            Value = color;
        }

        public ColorPoint(Color color, float time)
        {
            Value = color;
            Time = time;
        }

        public ColorPoint(Color color, float time, EaseType easing)
        {
            Value = color;
            Time = time;
            Easing = easing;
        }

        public ColorPoint(Color color, float time, EaseType easing, SplineType spline)
        {
            Value = color;
            Time = time;
            Easing = easing;
            Spline = spline;
        }

        internal override void Load(IEnumerable<object> pointArray)
        {
            try
            {
                if (pointArray.ElementAt(0) is float r)
                    Value.R = r;
                else
                    throw new InvalidCastException();

                if (pointArray.ElementAt(1) is float g)
                    Value.G = g;
                else
                    throw new InvalidCastException();

                if (pointArray.ElementAt(2) is float b)
                    Value.B = b;
                else
                    throw new InvalidCastException();

                if (pointArray.ElementAt(3) is float a)
                    Value.A = a;
                else
                    throw new InvalidCastException();

                LoadDefaults(ref pointArray, 4);
            }
            catch (Exception e) { throw new InvalidPointDataException(nameof(ColorPoint), e); }
        }

        internal override IEnumerable<object> Save()
        {
            object[] values = new object[7];
            values[0] = Value.R;
            values[1] = Value.G;
            values[2] = Value.B;
            values[3] = Value.A;
            SaveDefaultsAndRemoveEmpties(ref values, 4);
            return values;
        }
    }
}