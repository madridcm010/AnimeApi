using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.models
{
    public class Review
    {
        public int Id { get; set;}
        public int Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? Showid { get; set; }
        // Navigation
        public Anime? Anime { get; set; }
    }
}