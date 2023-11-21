using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize]
    public class CinemasController : Controller
    {
        private readonly ICinemasService _sevice;

        public CinemasController(ICinemasService service)
        {
            _sevice = service;
        }

        [AllowAnonymous]
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

        //Get: Cinemas/Details/{id}
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _sevice.GetByIdAsync(id);

            //if (cinemaDetails == null) return View("NotFound");
            //return View(cinemaDetails);
            if (cinemaDetails != null)
                return View(cinemaDetails);
            return View("NotFound");
        }

        //Get: Cinemas/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _sevice.GetByIdAsync(id);

            //if (cinemaDetails == null) return View("NotFound");
            //return View(cinemaDetails);
            if (cinemaDetails != null)
                return View(cinemaDetails);
            return View("NotFound");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Logo, Name, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _sevice.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));

        }

        //Get: Cinemas/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _sevice.GetByIdAsync(id);

            //if (cinemaDetails == null) return View("NotFound");
            //return View(cinemaDetails);
            if (cinemaDetails != null)
                return View(cinemaDetails);
            return View("NotFound");
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _sevice.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotFound");

            await _sevice.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
