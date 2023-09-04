using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moviApi.Dtos;
using moviApi.Models;

namespace moviApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    { 
        private readonly AppDbContext _context;

        public GenresController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> GetGenreAsync ()
        {
            var gen = await _context.genres.ToListAsync();
            return Ok(gen);
        }




        [HttpPost]
        public async Task<IActionResult> CreateGenreAsync(GenreDto genreDto)
        { var g = new Genre ();
            g.Name = genreDto.Name;
           
             await _context.genres.AddAsync(g);
            _context.SaveChanges();
             return Ok(g);
        }




        [HttpPut ("id")]
         public async Task<IActionResult> updateAsync( int id ,[FromBody]GenreDto genreDto)
        {
            var gen = await _context.genres.FindAsync(id);
            if (gen == null)
                return NotFound();
            gen.Name=genreDto.Name;
           
            _context.SaveChanges();
            return Ok(gen);
        }




        [HttpDelete ("id")]
        public async Task<IActionResult> DeletAsync (int id )
        {
            var gen = await _context.genres.FindAsync(id); 

            if (gen == null)
                    return NotFound();
            _context.genres.Remove(gen);
            _context.SaveChanges();
            return Ok(gen);

        }


    }
}
