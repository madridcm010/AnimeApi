using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly ApplicationDBContext _Context;
        public AnimeRepository(ApplicationDBContext Context){
            _context = Context;
        }
        Task<List<anime>> GetAllAsync(){
            
            return _context.Anime.ToListAsync();
        
        }

    }
}