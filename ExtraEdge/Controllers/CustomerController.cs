using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtraEdge.Models;
using ExtraEdge.Repositories;
using ExtraEdge.Services;

namespace EntraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;
        public CustomerController(ICustomerService ser)
        {
            service = ser;
        }
        // GET: api/Customer/GetAllServices
        [HttpGet]
        [Route("GetAllCustomer")]
        public IActionResult GetCustomers()
        {
            try
            {
                return new ObjectResult(service.GetCustomers());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // GET  api/Customer/GetCustomerById/1
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                return new ObjectResult(service.GetCustomerbyId(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex);
            }
        }

        // POST api/<CustomeerController>
        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            try
            {
                int res = service.AddCustomer(customer);
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

        // PUT api/<CustomerController>/5
        [HttpPost]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                int res = service.AddCustomer(customer);
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

        // DELETE api/<CustomerController>/5
        [HttpGet]
        [Route("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                int res = service.DeleteCustomer(id);
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
