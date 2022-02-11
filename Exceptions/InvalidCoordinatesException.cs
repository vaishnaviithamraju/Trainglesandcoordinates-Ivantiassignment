using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrianglesAndCoordinates
{
    public class InvalidCoordinatesException : Exception
    {
        public override string Message => "Please enter valid coordinates in the right sequence";
    }
}
