using eTickets.Data;
using eTickets.Data.Services;
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
    }
}
