using Microsoft.AspNetCore.Mvc;
using LitFibre.Interviews.SoftwareEngineer.Models.Data;
using LitFibre.Interviews.SoftwareEngineer.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace LitFibre.Interviews.SoftwareEngineer.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        private readonly DatabaseContext _context;

        public OrderController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ReadAll()
        {
            return await _context.Order.OrderBy(order => order.Id);
        }

        public async Task<IActionResult> ReadOne(int id)
        {
            return await _context.FirstOrDefaultAsync(order => order.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
            }

            return (OkResult);
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'DatabaseContext.Order'  is null.");
            }
            var comment = await _context.Order.FindAsync(id);
            if (comment != null)
            {
                _context.Order.Remove(comment);
            }

            await _context.SaveChangesAsync();
        }
    }
}
