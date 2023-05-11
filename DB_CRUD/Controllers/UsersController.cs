using DB_CRUD.Contexts;
using DB_CRUD.Models;
using DB_CRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DB_CRUD.Controllers
{
    public class UsersController : Controller
    {
        private CrudDbContext _context;

        public UsersController(CrudDbContext context)
        {
            _context = context;
        }
        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            return View(_context.Users);
        }
        [HttpGet("users/details")]
        public async Task<IActionResult> Details([FromQuery] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return BadRequest();
            }

            return View(user);
        }
        [HttpGet("users/create")]
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
        [HttpPost("users/create")]
        public async Task<IActionResult> Create([Bind("Login,Password,PasswordConfirmation, FirstName, LastName, DateOfBirth, Gender")] SignupUserDto user)
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
        [HttpGet("users/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(x=>x.UserID==id);
            if (user == null)
            {
                return NotFound();
            }
            
            return View(user);
        }
        //Додав до Edit атрибут пост, бо не знаю як зробити в MVC хороший put, використовуючи form
        [HttpPost("users/edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,Login,Password, FirstName, LastName, DateOfBirth, Gender")] User  user)
        {
            if (id != user.UserID)
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

        [HttpGet("users/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User user = await _context.Users.FirstOrDefaultAsync(x => x.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost("users/delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed( int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
