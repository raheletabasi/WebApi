using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Bussiness.Services.Interfaces;
using WebApi.Data.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            return new ObjectResult(_customerService.GetAllCustomer());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById([FromRoute] int id)
        {
            if (_customerService.ExistCustomer(id))
                return Ok(_customerService.GetCustomerById(id));
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.InsertCustomer(customer);
                return CreatedAtAction("GetCustomerById", new { id = customer.CustomerId }, customer);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer([FromRoute] int id,[FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.UpdateCustomer(customer);
                return Ok(customer);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            if (_customerService.ExistCustomer(id))
            {
                _customerService.DeleteCustomer(id);
                return Ok();
            }
            else
                return NotFound();       
        }
    }
}
