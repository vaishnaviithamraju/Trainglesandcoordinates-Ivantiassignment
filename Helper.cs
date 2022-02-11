using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace TrianglesAndCoordinates
{
    public static class Helper
    {
        public static int GetPixelLength()
        {
            var length = ConfigurationManager.AppSettings["PixelLength"];
            return Convert.ToInt32(length);
        }
    }
}
