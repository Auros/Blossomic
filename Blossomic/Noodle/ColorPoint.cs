using Blossomic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blossomic.Noodle
{
    public class ColorPointDefinition : PointDefinition<Color>
    {

    }

    public class Color
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }
    }

    internal class ColorPoint : Point<Color>
    {
        public override void Load(IEnumerable<object> pointArray)
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

        public override IEnumerable<object> Save()
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