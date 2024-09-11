using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Anime
{
    public class AnimeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string AniCompany { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        // Reviews
    }
}