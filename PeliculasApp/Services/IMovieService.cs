
using PeliculasApp.Models;

namespace PeliculasApp.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> ObtenerPeliculas();
    }
}
