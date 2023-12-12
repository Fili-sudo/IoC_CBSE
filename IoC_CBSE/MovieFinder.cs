using System.Linq;

namespace IoC_CBSE
{
    public class MovieFinder : IMovieFinder
    {
        private readonly IMovieLister _movieLister;

        public MovieFinder(IMovieLister movieLister)
        {
            _movieLister = movieLister;
        }

        public string GetMovie(string movieName)
        {
            var movies = _movieLister.GetMovies();
            var result = movies.FirstOrDefault(x => x.Contains(movieName));
            return result is not null ? result :
                "No movie was found";
        }
    }
}
