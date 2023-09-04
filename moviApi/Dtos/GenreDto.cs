using System.ComponentModel.DataAnnotations;

namespace moviApi.Dtos
{
    public class GenreDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
