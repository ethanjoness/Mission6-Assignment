using Microsoft.AspNetCore.Mvc;
using Mission6_Assignment.Data;
using Mission6_Assignment.Models;
using System.Linq;

namespace Mission6_Assignment.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        // Show all movies in collection
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        // GET - Show Create Form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST - Handle Form Submission
        [HttpPost]
        public IActionResult Create(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }

            return View(response);
        }
    }
}