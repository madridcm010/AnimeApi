using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.models;
using Microsoft.EntityFrameworkCore;

namespace Api.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Anime> Anime {get;set;}
        public DbSet<Review> Reviews {get; set;}  
    }
}