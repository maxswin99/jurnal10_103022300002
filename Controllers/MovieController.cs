using System;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace modul10_103022300002.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public class Movie
        {
            public string Title { get; set; }
            public string Director { get; set; }
            public string Stars { get; set; }
            public string Description { get; set; }

            public Movie(string Title, string Director, string Stars, string Description)
            {
                this.Title = Title;
                this.Director = Director;
                this.Stars = Stars;
                this.Description = Description;
            }

            public Movie() { }
        }

        public static class MovieData
        {
            public static List<Movie> dataMovie { get; private set; } = new List<Movie>
            {
                new Movie("The Shawshank Redemption", "Frank Darabont", "Frank Darabont", "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion"),
                new Movie("The Godfather", "Francis Ford Coppola", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son"),
                new Movie("The Dark Knight", "Christopher Nolan", "LedgerAaron Eckhar", "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness"),
            };
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return MovieData.dataMovie;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = MovieData.dataMovie;
            if (id < 0 || id >= data.Count)
            {
                return NotFound($"Movie dengan id {id} tidak ditemukan.");
            }
            return Ok(data[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie inputMovie)
        {
            var data = MovieData.dataMovie;
            data.Add(inputMovie);
            return Created($"/api/Movie/{data.Count - 1}", inputMovie);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie updatedMovie)
        {
            var data = MovieData.dataMovie;
            if (id < 0 || id >= data.Count)
            {
                return NotFound($"Movie dengan id {id} tidak ditemukan.");
            }
            data[id] = updatedMovie;
            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = MovieData.dataMovie;
            if (id < 0 || id >= data.Count)
            {
                return NotFound($"Movie dengan id {id} tidak ditemukan.");
            }
            data.RemoveAt(id);
            return Ok($"Movie dengan id {id} berhasil dihapus.");
        }
    }
}
