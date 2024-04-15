using Newtonsoft.Json;
using PeliculasApp.DTOs;
using PeliculasApp.Models;

namespace PeliculasApp.Services
{
    public class MoviesService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private const string URLAPI = "https://api.themoviedb.org/3/movie/";
        private const string URLIMAGE = "https://image.tmdb.org/t/p/w500";
        private const string APIKEY = "api_key=41ad7ea4dd973638091cebfd44e63e9b&language=es-ES&page=1";

        public MoviesService()
        {
            _httpClient = new();
        }
        public async Task<List<Movie>> ObtenerPeliculas(string param)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{URLAPI}{param}?{APIKEY}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ApiResponse resp = JsonConvert.DeserializeObject<ApiResponse>(content);
                    foreach (var movie in resp.Results)
                    {
                        movie.Poster_Path = $"{URLIMAGE}{movie.Poster_Path}";
                    }
                    return resp.Results;
                }
                else
                    return null;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<List<ValoratedMovie>> ObtenerPeliculasValoradas(string param)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{URLAPI}{param}?{APIKEY}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ApiResponseDetail resp = JsonConvert.DeserializeObject<ApiResponseDetail>(content);
                    foreach (var movie in resp.Results)
                    {
                        movie.Poster_Path = $"{URLIMAGE}{movie.Poster_Path}";
                    }
                    return resp.Results;
                }
                else
                    return null;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
