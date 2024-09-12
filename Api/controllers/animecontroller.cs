using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.data;
using Api.Dtos.Anime;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.controllers
{
    [Route("api/anime")]    
    public class Animecontroller : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IAnimeRepository _animeRepo;
        public Animecontroller(ApplicationDBContext context, IAnimeRepository animeRepo)
        {
            _animeRepo = animeRepo;
            _context = context;
        }    
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var anime = await _animeRepo.GetAllAsync();
            var animeDto = anime.Select(s => s.ToAnimeDto());
            return Ok(animeDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId([FromRoute]int id){
            var anime = await _context.Anime.FindAsync(id);
            if(anime == null){
                return NotFound();
            }

            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnimeRequestDto animeDto){
            var animemodel = animeDto.ToAnimeFromCreateDto();
            await _context.Anime.AddAsync(animemodel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetbyId), new{id = animemodel.Id}, animemodel.ToAnimeDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateAnimeRequestDto updateDto){
            var animemodel = await _context.Anime.FirstOrDefaultAsync(x => x.Id == id);

            if(animemodel == null){
                return NotFound();
            }
            animemodel.Name = updateDto.Name;
            animemodel.Author = updateDto.Author;
            animemodel.AniCompany = updateDto.AniCompany;
            animemodel.Genre = updateDto.Genre;
            await _context.SaveChangesAsync();
            return Ok(animemodel.ToAnimeDto());   
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var animemodel =  await _context.Anime.FirstOrDefaultAsync(x => x.Id == id);
            if(animemodel == null){
                return NotFound();
            }
            _context.Anime.Remove(animemodel);
           
           await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}