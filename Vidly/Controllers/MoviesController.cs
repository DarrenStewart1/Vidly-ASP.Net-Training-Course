
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
           // var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View();
        }
        public ViewResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genre
            };


            return View("MovieForm",viewModel);
        }



        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                GenreId = movie.GenreId,

                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);

        }


        public ActionResult MovieDetails(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };


                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

                _context.SaveChanges();
            
            

            return RedirectToAction("Index", "Movies");
        }


            /*
            private IEnumerable<Movie> GetMovies()
            {
                return new List<Movie>
                { new Movie { Id = 1, Name = "Shrek" },
                  new Movie { Id = 1, Name = "Wall-e" },

                };
            }
            */

            // GET: Movies/Random
            public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };




            var customers = new List<Customer>
            { new Customer { Name = "Customer 1"},
              new Customer{Name ="Customer 2"}
            };

           


           // var viewResult = new ViewResult();


            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers

            };

            return View(viewModel);

        }
    }
}

            //return Content("Hello World");

            //return HttpNotFound();

            //return new EmptyResult();

            //return RedirectToAction("Index", "Home", new{ page = 1, sortBy = "name" });
        
    
        /*
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if(String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";


            }

            return Content(String.Format("pageIndex={0}&sortB={1}", pageIndex,sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }


}
        */