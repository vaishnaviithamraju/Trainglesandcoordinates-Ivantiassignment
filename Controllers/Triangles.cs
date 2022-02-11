using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;

namespace TrianglesAndCoordinates.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrianglesController : ControllerBase
    {
        private readonly ILogger<TrianglesController> _logger;

        private readonly CoordinatesManager _coordinateManager = new CoordinatesManager();

        public TrianglesController(ILogger<TrianglesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{triangleName}")]
        public ActionResult<IList<Coordinate>> GetCoordinates(string triangleName)
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
        [HttpGet("GetTriangleName")]
        public ActionResult<string> GetTriangleName([FromQuery] string inputcoordinates)
        {
            try
            {
                var readthecoordinates =  HttpUtility.UrlDecode(inputcoordinates);
                List<Coordinate> vertices = JsonConvert.DeserializeObject<List<Coordinate>>(readthecoordinates);
                if (vertices == null || vertices.Count != 3)
                {
                    return BadRequest("Invalid Input");
                }
                var nameofTriangle = _coordinateManager.GetTriangleName(vertices);
                return nameofTriangle;

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
