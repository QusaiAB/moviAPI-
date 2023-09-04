using System.ComponentModel.DataAnnotations;

namespace moviApi.Models
{
    public class Movie
    {   
        public int  Id { get; set; }


        [MaxLength(250)]
        public   string  Title { get; set; }
         
        public double Rate { get; set; }

        public int Year { get; set; }


        [MaxLength(2500)]
        public string StoryLine { get; set; }

        public byte[] Pic { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }



    }
}
