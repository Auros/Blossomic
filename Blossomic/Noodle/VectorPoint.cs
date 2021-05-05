using Blossomic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blossomic.Noodle
{
    public class VectorPointDefinition : PointDefinition<Vector>
    {

    }

    public class Vector
    {
        public float? X { get; set; }
        public float? Y { get; set; }
        public float? Z { get; set; }
    }

    internal class VectorPoint : Point<Vector>
    {
        public override void Load(IEnumerable<object> pointArray)
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

        public override IEnumerable<object> Save()
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