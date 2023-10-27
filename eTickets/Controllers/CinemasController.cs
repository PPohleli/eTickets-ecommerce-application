using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _sevice;

        public CinemasController(ICinemasService service)
        {
            _sevice = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _sevice.GetAllAsync();
            return View(allCinemas);
        }

        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo, Name, Description")]Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _sevice.AddAsync(cinema);
            return RedirectToAction(nameof(Index));

        }
    }
}
