using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.data;
using Api.Interfaces;
using Api.models;   
namespace Api.Repository
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly ApplicationDBContext _context;
        public AnimeRepository(ApplicationDBContext context){
            _context = context;
        }
        public Task<List<Anime>> GetAllAsync(){
            
            return _context.Anime.ToListAsync();
        
        }

    }
}