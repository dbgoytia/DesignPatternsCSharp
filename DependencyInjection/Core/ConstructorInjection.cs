using System;

/*
 * The general goal is to have a MovieLister class that can list all movies by 
 * a particular director, and find them in any kind of given backend (xml, 
 * service, .xslx, SQL database and whatnot).
 *
 * 
 * Implements the Dependency Injection design pattern using constructor
 * injection. Basically we're using a constructor to decide how to inject
 * the inteface into the Lister Class.
 *
 */

namespace ConstructorInjection
{

    public interface IMovieFinder
    {
        List<Movie> FindAll();
    }

    public class ColonDelimitedMovieFinder : IMovieFinder
    {
        public string Filename { get; set; }

        public ColonDelimitedMovieFinder(string filename)
        {
            this.Filename = filename;
        }

        public List<Movie> FindAll()
        {
            // Whatever implementation is necessary for colon-sepparated files
            throw new NotImplementedException();
        }
    }

    public class Movie
    {
        public string Name { get; set; }

        public string Director { get; set; }
    }

    public class MovieLister
    {
        private IMovieFinder _finder;


        /*
         * The constructor will include all dependencies that needs injected of 
         * the service. We are covering any implementation of the IMovieFinder 
         * interface. Notice that you can also cover one or many dependencies.
         * 
         * Of course, this requires that the MovieLister class be told what
         * concrete implementation of the IMovieFinder interface to be used, 
         * typically on a different file.
         * 
         */
        public MovieLister(IMovieFinder finder)
        {
            this._finder = finder;
        }


        /*
         * Notice that the moviesDirectedBy method can remain unchanged, becuase
         * it is successfully decoupled.
         */
        public List<Movie> moviesDirectedBy(string director)
        {
            List<Movie> allMovies = this._finder.FindAll();
            List<Movie> moviesByDirector = new ();
            for (int i = 0; i < allMovies.Count; i++)
            {
                Movie movie = allMovies[i];
                if (movie.Director.Equals(director))
                {
                    moviesByDirector.Add(movie);
                }
            }
            return moviesByDirector;

        }
    }
}


