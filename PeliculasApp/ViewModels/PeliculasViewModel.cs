using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using PeliculasApp.DataAccess;
using PeliculasApp.DTOs;
using PeliculasApp.Utilidades;

namespace PeliculasApp.ViewModels
{
    public partial class PeliculasViewModel : ObservableObject, IQueryAttributable
    {
        private readonly PeliculaDbContext _dbContext;
        private const string URLIMAGE = "https://image.tmdb.org/t/p/w500";

        [ObservableProperty]
        private MovieDTO peliculaDto = new();

        [ObservableProperty]
        private string tituloPelicula;

        private int IdPelicula;

        [ObservableProperty]
        private bool loadingEsVisible = false;
        public PeliculasViewModel(PeliculaDbContext context)
        {
            _dbContext = context;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            LoadingEsVisible = true;
            IdPelicula = int.Parse(query["id"].ToString());
            FormatLenguajes formatLenguajes = new();
            await Task.Run(async () =>
            {
                var encontrado = await _dbContext.Movies.FirstAsync(e => e.Id == IdPelicula);
                PeliculaDto.Id = encontrado.Id;
                PeliculaDto.Ooverview = encontrado.Overview;
                PeliculaDto.Adult = encontrado.Adult;
                PeliculaDto.Backdrop_Path = $"{URLIMAGE}{encontrado.Backdrop_Path}" ;
                PeliculaDto.Original_Language = formatLenguajes.FormatearIdioma(encontrado.Original_Language);
                PeliculaDto.Popularity = encontrado.Popularity;
                PeliculaDto.Poster_Path = encontrado.Poster_Path;
                PeliculaDto.Vote_Average = encontrado.Vote_Average;
                PeliculaDto.Video = encontrado.Video;
                PeliculaDto.Original_Title = encontrado.Original_Title;
                PeliculaDto.Title = encontrado.Title;
                PeliculaDto.Release_Date = encontrado.Release_Date;
                PeliculaDto.Vote_Count = encontrado.Vote_Count;
                MainThread.BeginInvokeOnMainThread(() => { LoadingEsVisible = false; });
            });
        }

    }
}
