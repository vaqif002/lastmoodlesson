using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFrontToBack.DAL;
using WebFrontToBack.Models;
using WebFrontToBack.ViewModel;

namespace WebFrontToBack.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<Service> services = await _context.Services.ToListAsync();
            return View(services);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Service service = new Service();
            ServiceVM serviceVM = new ServiceVM()
            {
                categories = await _context.Categories.ToListAsync(),
                services = service

            };
            return View(serviceVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceVM service)
        {
            service.services.IsDeleted = false;
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.Services.AddAsync(service.services); 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int Id)
        {
            Service? service = _context.Services.Find(Id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost]
        public IActionResult Update(Service service)
        {
            Service? editedService = _context.Services.Find(service.Id);
            if (editedService == null)
            {
                return NotFound();
            }
            editedService.Name = service.Name;
            _context.Services.Update(editedService);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            Service? service = _context.Services.Find(Id);
            if (service == null)
            {
                return NotFound();
            }
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

