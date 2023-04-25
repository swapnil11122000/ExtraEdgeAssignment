using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtraEdge.Models;
using ExtraEdge.Repositories;
using ExtraEdge.Services;

namespace EntraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService service;
        public PurchaseController(IPurchaseService ser)
        {
            service = ser;
        }
        [HttpGet]
        [Route("GetAllPurchases")]
        public IActionResult GetPurchases()
        {
            try
            {
                return new ObjectResult(service.GetPurchases());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        [HttpGet]
        [Route("GetPurchaseById/{id}")]
        public IActionResult GetPurchaseById(int id)
        {
            try
            {
                return new ObjectResult(service.GetPurchasebyId(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        [HttpPost]
        [Route("AddPurchase")]
        public IActionResult AddPurchase([FromBody] Purchase purchase)
        {
            try
            {
                int res = service.AddPurchase(purchase);
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
        [Route("UpdatePurchase")]
        public IActionResult UpdatePurchase([FromBody] Purchase purchase)
        {
            try
            {
                int res = service.UpdatePurchase(purchase);
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
        [Route("DeletePurchase/{id}")]
        public IActionResult DeletePurchase(int id)
        {
            try
            {
                int res = service.DeletePurchase(id);
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
