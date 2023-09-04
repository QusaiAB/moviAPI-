using System.ComponentModel.DataAnnotations;

namespace moviApi.Dtos
{
    public class MovieDto
    {
        [MaxLength(250)]
        public string Title { get; set; }

        public double Rate { get; set; }

        public int Year { get; set; }


        [MaxLength(2500)]
        public string StoryLine { get; set; }

        public IFormFile Pic { get; set; }

        public int GenreId { get; set; }

    }
}
