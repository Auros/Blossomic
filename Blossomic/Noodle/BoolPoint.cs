using Blossomic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blossomic.Noodle
{
    public class BoolPointDefinition : PointDefinition<bool>
    {

    }

    internal class BoolPoint : Point<bool>
    {
        public override void Load(IEnumerable<object> pointArray)
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

        public override IEnumerable<object> Save()
        {
            object[] values = new object[4];
            values[0] = Value ? 1 : 0;
            SaveDefaultsAndRemoveEmpties(ref values, 1);
            return values;
        }
    }
}
