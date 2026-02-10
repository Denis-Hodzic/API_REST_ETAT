using SeriesMVVM.Models.EntityFramework;
using SeriesMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SeriesMVVM
{
    public class WSService : IService
    {
        private readonly HttpClient httpClient;

        public WSService(string uriDevice)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(uriDevice)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Serie?> GetSerieAsync(string controller, int id)
        {
            try
            {
                // api/series/1 -> controller = "series"
                var url = string.Concat(controller.TrimEnd('/'), "/", id);
                return await httpClient.GetFromJsonAsync<Serie>(url);
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Serie>?> GetAllSeriesAsync(string controller)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Serie>>(controller);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> PostSerieAsync(string controller, Serie serie)
        {
            try
            {
                var resp = await httpClient.PostAsJsonAsync(controller, serie);
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> PutSerieAsync(string controller, int id, Serie serie)
        {
            try
            {
                var url = string.Concat(controller.TrimEnd('/'), "/", id);
                var resp = await httpClient.PutAsJsonAsync(url, serie);
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteSerieAsync(string controller, int id)
        {
            try
            {
                var url = string.Concat(controller.TrimEnd('/'), "/", id);
                var resp = await httpClient.DeleteAsync(url);
                return resp.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

    }
}
