using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFrontToBack.DAL;
using WebFrontToBack.Models;

namespace WebFrontToBack.Controllers
{
    public class RecektController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public RecektController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> IndexAsync()
        { 
            return View(await _appDbContext.RecentWorks.ToListAsync());
        }
    }
}
