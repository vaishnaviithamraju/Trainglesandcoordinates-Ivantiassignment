using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrianglesAndCoordinates
{
    public class CoordinatesManager
    {
        //pixellength needs to be moved to a config file.
        int pixellength = 10;
        public Task<List<(int, int)>> GetCoordinates(string triangleName)
        {
            //split the name into two parts
            var alphabetArray = Regex.Split(triangleName.ToUpper().Trim(), "(?<=\\D)(?=\\d)|(?<=\\d)(?=\\D)");
            char triangleRow = alphabetArray[0].ToCharArray()[0];
            int triangleCol = Convert.ToInt32(alphabetArray[1]);
            //validate the two parts based on ascii values.
            if (alphabetArray.Length != 2 || triangleRow < 'A' || triangleRow > 'Z' || triangleCol < 1 || triangleCol > 12)
            {
                throw new InvalidTriangleInputException();
            }
            Coordinates coordinates = new Coordinates();
            var asciidiff = triangleRow - 'A';
            int y1 = (asciidiff) * 10;
            //derive the first coordinate based on even and odd 
            //add 10 to both coordinates of the first coordinate to get the third.
            //add to x or y coordinate based on even or odd to derive the second coordinate.
            int x1, x2, y2;
            if (triangleCol % 2 == 0)
            {
                x1 = ((triangleCol - 2) / 2) * pixellength;
                x2 = x1 + pixellength;
                y2 = y1;
            }
            else
            {
                x1 = ((triangleCol - 1) / 2) * pixellength;
                x2 = x1;
                y2 = y1 + pixellength;
            }
            coordinates.ListOfCoordinates.Add((x1, y1));
            coordinates.ListOfCoordinates.Add((x2, y2));
            coordinates.ListOfCoordinates.Add((x1 + pixellength, y1 + pixellength));
            return Task.FromResult(coordinates.ListOfCoordinates);

        }

        public string GetTriangleName((int, int) V1, (int, int) V2, (int, int) V3)
        {
            //V2 refers to right angled vertex. Remaining two are the other two.
            //try to reverse engineer the other method ?
        }
    }
}
