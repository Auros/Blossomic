using Blossomic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blossomic.Noodle
{
    public class FloatPointDefinition : PointDefinition<float>
    {

    }

    internal class FloatPoint : Point<float>
    {
        public override void Load(IEnumerable<object> pointArray)
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

        public override IEnumerable<object> Save()
        {
            object[] values = new object[4];
            values[0] = Value;
            SaveDefaultsAndRemoveEmpties(ref values, 1);
            return values;
        }
    }
}