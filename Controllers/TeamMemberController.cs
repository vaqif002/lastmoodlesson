using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFrontToBack.DAL;
using WebFrontToBack.Models;
using WebFrontToBack.ViewModel;

namespace WebFrontToBack.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TeamMemberController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> IndexAsync()
        {
         
            return View();
        }
    }
}
