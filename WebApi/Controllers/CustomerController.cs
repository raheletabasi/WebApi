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
        public async Task<IActionResult> GetAllCustomer()
        {
            return new ObjectResult(_customerService.GetAllCustomer());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            if (await _customerService.ExistCustomer(id))
                return Ok(_customerService.GetCustomerById(id));
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.InsertCustomer(customer);
                return CreatedAtAction("GetCustomerById", new { id = customer.CustomerId }, customer);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id,[FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.UpdateCustomer(customer);
                return Ok(customer);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            if (await _customerService.ExistCustomer(id))
            {
                await _customerService.DeleteCustomer(id);
                return Ok();
            }
            else
                return NotFound();       
        }
    }
}
