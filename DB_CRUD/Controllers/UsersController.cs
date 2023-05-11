using DB_CRUD.Contexts;
using DB_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DB_CRUD.Controllers
{
    public class UsersController : Controller
    {
        private CrudDbContext _context;

        public UsersController(CrudDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(_context.Users);
        }

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
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Login,Password,PasswordConfirmation, FirstName, LastName, DateOfBirth, Gender")] UserDTO user)
        {
            try
            {
                User newUser=new User() 
                { FirstName= user.FirstName, LastName=user.LastName,
                    Login=user.Login, Password=user.Password,
                    DateOfBirth=user.DateOfBirth,Gender=user.Gender
                };
                _context.Users.Add(newUser);
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
