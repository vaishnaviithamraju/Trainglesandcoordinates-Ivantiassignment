using System;
using System.Collections.Generic;

namespace TrianglesAndCoordinates
{
    //public class Coordinates
    //{
    //    // public Tuple<int,int> Coordinate { get; set; }
    //    public IList<Coordinate> ListOfCoordinates { get; set; } = new List<Coordinate>();

    //}

    public class Coordinate
    {
        public Coordinate()
        {
        }

        public Coordinate(int x,int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}
