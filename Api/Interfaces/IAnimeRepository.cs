using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.models;
namespace Api.Interfaces
{
    public interface IAnimeRepository{
        Task<List<Anime>> GetAllAsync();
    }
}