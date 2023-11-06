using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context): base(context) 
        { 
            _context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            //var theResponce = new NewMovieDropdownsVM();

            //theResponce.Actors = await _context.Actors.OrderBy(ac => ac.FullName).ToListAsync();
            //theResponce.Cinemas = await _context.Cinemas.OrderBy(c => c.Name).ToListAsync();
            //theResponce.Producers = await _context.Producers.OrderBy(p => p.FullName).ToListAsync();

            var theResponce = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(ac => ac.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(c => c.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(p => p.FullName).ToListAsync()
            };
            return theResponce;
        }
    }
}
