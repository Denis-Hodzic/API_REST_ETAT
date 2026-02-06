using SeriesMVVM.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesMVVM.Services
{
    public interface IService
    {
        Task<List<Serie>> GetSerieAsync(string nomControleur);
    }
}
