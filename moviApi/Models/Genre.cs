﻿using System.ComponentModel.DataAnnotations;

namespace moviApi.Models
{
    public class Genre
    { public  int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }    
    }
}
