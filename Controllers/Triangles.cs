using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace TrianglesAndCoordinates.Controllers
{
    [ApiController]
    [System.Web.Http.Route("[controller]")]
    public class Triangles : ControllerBase
    {
        private readonly ILogger<Triangles> _logger;

        private readonly CoordinatesManager _coordinateManager;

        public Triangles(ILogger<Triangles> logger, CoordinatesManager coordinatesManager)
        {
            _logger = logger;
            _coordinateManager = coordinatesManager;
        }

        [System.Web.Http.HttpGet]
        public ActionResult<List<(int, int)>> GetCoordinates(string triangleName)
        {
            try
            {
                if (string.IsNullOrEmpty(triangleName))
                {
                    return BadRequest("Invalid Input");
                }
                var coordinates = _coordinateManager.GetCoordinates(triangleName);
                return Ok(coordinates);

            }
            catch (InvalidTriangleInputException ex)
            {
                //or i can choose to ignore these requests ? 
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public ActionResult<string> GetTriangleName((int, int)[] vertices)
        {
            try
            {
                if (vertices.Length == 0 || vertices == null)
                {
                    return BadRequest("Invalid Input");
                }
                var coordinates = _coordinateManager.GetTriangleName(vertices);
                return Ok(coordinates);

            }
            catch (InvalidTriangleInputException ex)
            {
                //or i can choose to ignore these requests ? 
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
