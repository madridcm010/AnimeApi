using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Anime;
using Api.models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Api.Mappers
{
    public static class AnimeMappers
    {
        public static AnimeDto ToAnimeDto(this Anime animemodel){
            return new AnimeDto{
                Id = animemodel.Id,
                Name = animemodel.Name,
                Author = animemodel.Author,
                AniCompany = animemodel.AniCompany,
                Genre = animemodel.Genre
            };
        }
        public static Anime ToAnimeFromCreateDto(this CreateAnimeRequestDto AnimeDto){
            return new Anime{
                Name = AnimeDto.Name,
                Author = AnimeDto.Author,
                AniCompany = AnimeDto.AniCompany,
                Genre = AnimeDto.Genre
            };
        }
    }
}