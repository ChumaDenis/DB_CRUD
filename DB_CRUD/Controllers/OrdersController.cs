using Microsoft.AspNetCore.Mvc;

namespace DB_CRUD.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
