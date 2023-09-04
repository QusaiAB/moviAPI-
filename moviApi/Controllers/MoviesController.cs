using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moviApi.Dtos;
using moviApi.Models;

namespace moviApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private List<string> alaweedAcstion = new List<string> { ".pnj ", ".jpj" };
        private long MaxSize = 1048576;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _context.Movies.Include(g => g.Genre).ToListAsync();
            return Ok(movies);
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        { var movie = await _context.Movies.Include(g => g.Genre).SingleOrDefaultAsync(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }


        [HttpGet("GetByGenreId")]
        public async Task<IActionResult> GetByGenreIdAsync(int generId)


        {
            var GId = await _context.genres.SingleOrDefaultAsync(g => g.Id == generId);
            if (GId == null)
                return NotFound("there is no genre with this number " + generId);

            var movies = await _context.Movies.Where(m => m.GenreId == generId).Include(g => g.Genre).ToListAsync();
            return Ok(movies);
        }

        [HttpPost]

        public async Task<IActionResult> CreateAsync([FromForm] MovieDto dto)

        { if (!alaweedAcstion.Contains(dto.Pic.FileName.ToLower()))
                return BadRequest("the only type is pnj jpj");
            if (dto.Pic.Length > MaxSize)
                return BadRequest("the most size is 1 m");
            var IsValied = await _context.genres.AnyAsync(g => g.Id == dto.GenreId);
            if (!IsValied)
                return BadRequest("the genre id is not valied");



            using var datastrem = new MemoryStream();
            await dto.Pic.CopyToAsync(datastrem);

            var movie = new Movie
            { Pic = datastrem.ToArray(),
                GenreId = dto.GenreId,
                StoryLine = dto.StoryLine,
                Rate = dto.Rate,
                Year = dto.Year,
                Title = dto.Title,

            };
            await _context.Movies.AddAsync(movie);
            _context.SaveChanges();
            return Ok(movie);


        }



        [HttpPut ("id")]
     public async Task<IActionResult> updateAsenc (int id, [FromBody]MovieDto movieDto)
   
    {
        var movie = await _context.Movies.Include(g => g.Genre).SingleOrDefaultAsync(m => m.Id == id);
        if (movie == null)
            return NotFound();

        else return Ok(movie);
    }








        [HttpDelete]
        public async Task<IActionResult> deletAsync(int id )
        {
            var movi = await _context.Movies.FindAsync(id);

            if (movi == null)
                return NotFound();

            _context.Movies.Remove(movi);
            _context.SaveChanges();
            return Ok(movi);

                 

        }

    }
}
