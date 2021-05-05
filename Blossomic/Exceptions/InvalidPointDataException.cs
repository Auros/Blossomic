using System;

namespace Blossomic.Exceptions
{
    public class InvalidPointDataException : Exception
    {
        public InvalidPointDataException(string pointTypeName, Exception inner) : base($"Invalid point type when trying to parse {pointTypeName}", inner)
        {
            
        }
    }
}