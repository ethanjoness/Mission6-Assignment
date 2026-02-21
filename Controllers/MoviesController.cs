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
        // GET
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            return View(movie);
        }

        // POST
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // GET
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            return View(movie);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}