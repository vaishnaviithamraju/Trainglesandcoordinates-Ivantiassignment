using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrianglesAndCoordinates
{
    public class InvalidTriangleInputException : Exception
    {
        public override string Message => "Name of the triangle is invalid.";
    }
}
