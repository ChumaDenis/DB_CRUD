using Microsoft.AspNetCore.Mvc;

namespace DB_CRUD.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
