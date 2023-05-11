using DB_CRUD.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace DB_CRUD.Controllers
{
    public class UsersController : Controller
    {
        private CrudDbContext _context;

        public UsersController(CrudDbContext context) 
        {
            _context= context;
        }


        public IActionResult Index()
        {
            return View(_context.Users);
        }
    }
}
