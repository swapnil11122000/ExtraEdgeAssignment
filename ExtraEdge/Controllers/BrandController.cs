using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtraEdge.Models;
using ExtraEdge.Repositories;
using ExtraEdge.Services;

namespace EntraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService service;
        public BrandController(IBrandService ser)
        {
            service = ser;
        }
        // GET: api/Brand/GetAllBrands
        [HttpGet]
        [Route("GetAllBrands")]
        public IActionResult GetBrands()
        {
            try
            {
                return new ObjectResult(service.GetAllBrands());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // GET  api/Brand/GetBrandById/1
        [HttpGet]
        [Route("GetBrandById/{id}")]
        public IActionResult GetbrandById(int id)
        {
            try
            {
                return new ObjectResult(service.GetBrandById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // POST api/<BrandController>
        [HttpPost]
        [Route("AddBrand")]
        public IActionResult AddBrand([FromBody] Brand brand)
        {
            try
            {
                int res = service.AddBrand(brand);
                if (res == 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<BrandController>/5
        [HttpPost]
        [Route("UpdateBrand")]
        public IActionResult Updatebrand([FromBody] Brand brand)
        {
            try
            {
                int res = service.UpdateBrand(brand);
                if (res == 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/<BrandController>/5
        [HttpGet]
        [Route("DeleteBrand/{id}")]
        public IActionResult DeleteBrand(int id)
        {
            try
            {
                int res = service.DeleteBrand(id);
                if (res == 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }

}
