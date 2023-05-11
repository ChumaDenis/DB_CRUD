using DB_CRUD.Contexts;
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

        public IActionResult Index()
        {
            return View(_context.Orders);
        }



    }
}
