using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtraEdge.Models;
using ExtraEdge.Repositories;
using ExtraEdge.Services;

namespace EntraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IMobileService service;
        public MobileController(IMobileService ser)
        {
            service = ser;
        }
        // GET: api/Mobile/GetAllMobiles
        [HttpGet]
        [Route("GetAllMobiles")]
        public IActionResult Getmobiles()
        {
            try
            {
                return new ObjectResult(service.GetMobiles());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        [HttpGet]
        [Route("GetMobileById/{id}")]
        public IActionResult GetMobileById(int id)
        {
            try
            {
                return new ObjectResult(service.GetMobilebyId(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        [HttpPost]
        [Route("AddMobile")]
        public IActionResult AddMobile([FromBody] Mobile mobile)
        {
            try
            {
                int res = service.AddMobile(mobile);
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

        [HttpPost]
        [Route("UpdateMobile")]
        public IActionResult Updatemobile([FromBody] Mobile mobile)
        {
            try
            {
                int res = service.Updatemobile(mobile);
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

        [HttpGet]
        [Route("DeleteMobile/{id}")]
        public IActionResult DeleteMobile(int id)
        {
            try
            {
                int res = service.Deletemobile(id);
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
