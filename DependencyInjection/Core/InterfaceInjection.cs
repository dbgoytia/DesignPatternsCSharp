using System;

/*
 * The general goal is to have a MovieLister class that can list all movies by 
 * a particular director, and find them in any kind of given backend (xml, 
 * service, .xslx, SQL database and whatnot).
 *
 *
 * This implementation uses the Interface Injection pattern. Basically what
 * we can see is that we're using interface implementation as opposed to 
 * constructors, or properties.
 */

namespace InterfaceInjection
{

    public interface IMovieFinder
    {
        List<Movie> FindAll();
    }

    /*
     * This is the interface that we will use to perform the injection through.
     * This would be implemented by whoever provides the MovieFinder interface.
     */
    public interface IInjectFinder
    {
        void InjectFinder(IMovieFinder finder);
    }

    /*
     * This interface injects the filename to the IMovieFinder concrete impl
     */
    public interface IInjectFinderFilename
    {
        void InjectFilename(string filename);
    }

    public class ColonDelimitedMovieFinder : IMovieFinder, IInjectFinderFilename
    {
        public string Filename { get; set; }


        public ColonDelimitedMovieFinder()
        {

        }

        public List<Movie> FindAll()
        {
            /*
             * Whatever implementation is necessary for colon-sepparated files
             */
            throw new NotImplementedException();
        }

        public void InjectFilename(string filename)
        {
            this.Filename = filename;
        }
    }

    public class Movie
    {
        public string Name { get; set; }

        public string Director { get; set; }
    }

    /*
     * Whatever class intends to use the Finder, needs to implement the Inject
     * Finder interface
     */
    public class MovieLister : IInjectFinder
    {
        private IMovieFinder _finder;

        public MovieLister()
        {
            
        }

        public void InjectFinder(IMovieFinder finder)
        {
            this._finder = finder;
        }


        /*
         * Notice that the moviesDirectedBy method can remain unchanged, becuase
         * it is successfully decoupled
         */
        public List<Movie> moviesDirectedBy(string director)
        {
            List<Movie> allMovies = this._finder.FindAll();
            List<Movie> moviesByDirector = new();
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


