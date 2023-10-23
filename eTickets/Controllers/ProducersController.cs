using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        //Get: Producers/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
                return View("NotFound");
            return View(producerDetails);
        }

        //Get: Producers/Create - this display only an empty view used to add a producer
        public IActionResult Create()
        {
            return View();
        }

        //Post (Add): this display only an empty view used to add a producer
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")]Producer producer)
        {
            if (!ModelState.IsValid)
                return View(producer);
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Producers/Edit/ {id} - this display a view with specific producer details to edit 
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
                return View("NotFound");
            return View(producerDetails);
        }

        //Post (Add): this display only an empty view used to add a producer
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
                return View(producer);
            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
    }
}
