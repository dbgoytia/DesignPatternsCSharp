using System;


/*
 * This first example shows a naive implementation on how to decouple a class
 * to be used within our service. The goal is to have a MovieLister service
 * that can list all movies by a given director.
 * 
 */
namespace NaiveImplementation
{
    public interface IMovieFinder
    {
        List<Movie> FindAll();
    }

    public class Movie
    {
        public string Name { get; set; }

        public string Director { get; set; }
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

    public class MovieLister
    {
        private IMovieFinder _finder;

        public MovieLister()
        {
            /*
             * What happens when someone attempting to use the service wants a
             * copy? They would also need to have the movies in a ColonDelimited 
             * file. What if they are using something different, like a SQL 
             * Database, an XML file or anything else to store this? In this
             * case we would need different classes to grab the data
             * 
             */
            this._finder = new ColonDelimitedMovieFinder("movies.txt");
        }


        /*
         * Note that despite the problem fo handling different types of storage
         * for the actual data, the moviesDirectedBy can remain unchanged.
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


