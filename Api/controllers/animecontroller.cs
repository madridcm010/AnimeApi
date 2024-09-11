using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.data;
using Api.Dtos.Anime;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers
{
    [Route("api/anime")]    
    public class Animecontroller : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public Animecontroller(ApplicationDBContext context)
        {
            _context = context;
        }    
        [HttpGet]
        public IActionResult GetAll(){
            var anime = _context.Anime.ToList()
                .Select(s => s.ToAnimeDto());
            return Ok(anime);
        }
        [HttpGet("{id}")]
        public IActionResult GetbyId([FromRoute]int id){
            var anime = _context.Anime.Find(id);
            if(anime == null){
                return NotFound();
            }

            return Ok(id);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateAnimeRequestDto animeDto){
            var animemodel = animeDto.ToAnimeFromCreateDto();
            _context.Anime.Add(animemodel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetbyId), new{id = animemodel.Id}, animemodel.ToAnimeDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateAnimeRequestDto updateDto){
            var animemodel = _context.Anime.FirstorDefault(x=> x.Id == id);

            if(animemodel == null){
                return NotFound();
            }
            animemodel.Id = updateDto.Id;
            animemodel.Name = updateDto.Name;
            animemodel.Author = updateDto.Author;
            animemodel.AniCompany = updateDto.AniCompany;
            animemodel.Genre = updateDto.Genre;
            _context.SaveChanges();
            return Ok(animemodel.ToAnimeDto());   
        }
    }
}