
using PeliculasApp.DTOs;
using PeliculasApp.Models;

namespace PeliculasApp.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> ObtenerPeliculas(string param);
        Task<List<ValoratedMovie>> ObtenerPeliculasValoradas(string param);

    }
}
