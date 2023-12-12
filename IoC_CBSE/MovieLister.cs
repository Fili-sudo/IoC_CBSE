using System.Collections.Generic;

namespace IoC_CBSE
{
    public class MovieLister : IMovieLister
    {
        private List<string> movies;

        public MovieLister()
        {
            movies = new List<string>()
            {
                "Harry Potter and the Philosophical Stone",
                "Star Wars: A New Hope",
                "Star Wars: The Phantom Menace",
                "The Godfather",
                "Inglorious Bastards",
                "The Shawshank Redemption"
            };
        }

        public List<string> GetMovies()
        {
            return movies;
        }
    }
}
