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
        Task<List<Serie>?> GetAllSeriesAsync(string controller);
        Task<Serie?> GetSerieAsync(string controller, int id);
        Task<bool> PostSerieAsync(string controller, Serie serie);
        Task<bool> PutSerieAsync(string controller, int id, Serie serie);
        Task<bool> DeleteSerieAsync(string controller, int id);
    }
}
