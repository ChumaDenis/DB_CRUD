using DB_CRUD.Contexts;
using DB_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DB_CRUD.Controllers
{
    public class OrdersController : Controller
    {
        private CrudDbContext _context;

        public OrdersController(CrudDbContext context)
        {
            _context = context;
        }
        [HttpGet("orders")]
        public async Task<IActionResult> Index()
        {

            return View(await _context.Orders.Include(o => o.User).ToListAsync());
        }
        [HttpGet("orders/details")]
        public async Task<IActionResult> Details([FromQuery] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Orders.Include(o => o.User)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return BadRequest();
            }

            return View(user);
        }

        [HttpGet("orders/create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("orders/edit")]
        public async Task<IActionResult> Create([Bind("OrderDate,OrderCost,ItemsDescription,ShippingAddress")] Order order)
        {
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("orders/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost("orders/edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,UserID,OrderDate,OrderCost,ItemsDescription,ShippingAddress")] Order user)
        {
            if (id != user.OrderID)
            {
                return NotFound();
            }

            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
