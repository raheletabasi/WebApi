using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        WebApi_DBContext _context;

        public CustomerController(WebApi_DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            return new ObjectResult(_context.Customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomerById", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id,[FromBody] Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
