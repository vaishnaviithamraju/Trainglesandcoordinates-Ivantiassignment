using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrianglesAndCoordinates
{
    public class CoordinatesManager
    {
        //int pixellength = Helper.GetPixelLength();
        int pixellength = 10;
        public Task<List<Coordinate>> GetCoordinates(string triangleName)
        {
            //split the name into two parts
            var alphabetArray = Regex.Split(triangleName.ToUpper().Trim(), "(?<=\\D)(?=\\d)|(?<=\\d)(?=\\D)");
            if (alphabetArray.Length < 2)
            {
                throw new InvalidTriangleInputException();
            }
            char triangleRow = alphabetArray[0].ToCharArray()[0];
            int triangleCol = Convert.ToInt32(alphabetArray[1]);
            //validate the two parts based on ascii values.
            if (triangleRow < 'A' || triangleRow > 'Z' || triangleCol < 1 || triangleCol > 12)
            {
                throw new InvalidTriangleInputException();
            }
            List<Coordinate> coordinates = new List<Coordinate>();
            var asciidiff = triangleRow - 'A';
            Coordinate vertex1 = new Coordinate
            {
                YCoordinate = (asciidiff) * 10
            };
            //derive the first coordinate based on even and odd 
            //add 10 to both coordinates of the first coordinate to get the third.
            //add to x or y coordinate based on even or odd to derive the second coordinate.
            Coordinate vertex2 = new Coordinate();
            if (triangleCol % 2 == 0)
            {
                vertex1.XCoordinate = ((triangleCol - 2) / 2) * pixellength;
                vertex2.XCoordinate = vertex1.XCoordinate + pixellength;
                vertex2.YCoordinate = vertex1.YCoordinate;
            }
            else
            {
                vertex1.XCoordinate = ((triangleCol - 1) / 2) * pixellength;
                vertex2.XCoordinate = vertex1.XCoordinate;
                vertex2.YCoordinate = vertex1.YCoordinate + pixellength;
            }
            coordinates.Add(vertex1);
            coordinates.Add(vertex2);
            coordinates.Add(new Coordinate(vertex1.XCoordinate + pixellength, vertex1.YCoordinate + pixellength));
            return Task.FromResult(coordinates);

        }

        public string GetTriangleName(List<Coordinate> input_coordinates)
        {
            Coordinate vertx2 = input_coordinates[1];
            Coordinate vertx1 = input_coordinates[0];
            Coordinate vertx3 = input_coordinates[2];
            int A = (int)Math.Pow((vertx2.XCoordinate - vertx1.XCoordinate), 2) +
                    (int)Math.Pow((vertx2.YCoordinate - vertx1.YCoordinate), 2);

            int B = (int)Math.Pow((vertx3.XCoordinate - vertx2.XCoordinate), 2) +
                    (int)Math.Pow((vertx3.YCoordinate - vertx2.YCoordinate), 2);

            int C = (int)Math.Pow((vertx3.XCoordinate - vertx1.XCoordinate), 2) +
                    (int)Math.Pow((vertx3.YCoordinate - vertx1.XCoordinate), 2);

            if (C != (A + B) ||
                vertx3.YCoordinate - vertx1.YCoordinate != pixellength 
                || vertx3.XCoordinate - vertx1.XCoordinate != pixellength)
            {
                throw new InvalidCoordinatesException();
            }

            char firstletter = (char)((vertx1.YCoordinate / 10) + 65);

            var square = (vertx1.XCoordinate / 10) + 1;
            int secondletter = vertx2.XCoordinate > vertx1.XCoordinate ? square * 2 : square * 2 - 1;

            return (Convert.ToString(firstletter) + secondletter);
        }
    }
}
