using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PeliculasApp.DataAccess;
using PeliculasApp.DTOs;
using PeliculasApp.Models;
using PeliculasApp.Services;
using PeliculasApp.Utilidades;
using PeliculasApp.Views;
using System.Collections.ObjectModel;

namespace PeliculasApp.ViewModels
{
    public partial class ValoradasViewModel : ObservableObject
    {
        private readonly PeliculaDbContext _dbContext;

        [ObservableProperty]
        private ObservableCollection<ValoratedMovieDTO> listaPeliculasValoradas = new();

        public ValoradasViewModel(PeliculaDbContext context)
        {
            _dbContext = context;
            MainThread.BeginInvokeOnMainThread(new Action(async () => await ObtenerPeliculasValoradas()));
        }

        public async Task ObtenerPeliculasValoradas()
        {
            FormatLenguajes formatLenguajes = new();
            var lista = await _dbContext.ValoratedMovies.ToListAsync();

            if (!lista.Any())
            {
                MoviesService moviesService = new();
                var resp = await moviesService.ObtenerPeliculas(StringConstApi.TopRated);
                foreach (var item in resp)
                {
                    _dbContext.ValoratedMovies.Add(new ValoratedMovie
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Adult = item.Adult,
                        Backdrop_Path = item.Backdrop_Path,
                        Original_Language = item.Original_Language,
                        Original_Title = item.Original_Title,
                        Popularity = item.Popularity,
                        Poster_Path = item.Poster_Path,
                        Release_Date = item.Release_Date,
                        Video = item.Video,
                        Vote_Average = item.Vote_Average,
                        Vote_Count = item.Vote_Count,
                        Overview = item.Overview
                    });
                }
                await _dbContext.SaveChangesAsync();
                lista = await _dbContext.ValoratedMovies.ToListAsync();
            }

            ListaPeliculasValoradas = new(
                lista.Select(item => new ValoratedMovieDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Adult = item.Adult,
                    Backdrop_Path = item.Backdrop_Path,
                    Original_Language = formatLenguajes.FormatearIdioma(item.Original_Language),
                    Original_Title = item.Original_Title,
                    Popularity = item.Popularity,
                    Poster_Path = item.Poster_Path,
                    Release_Date = item.Release_Date,
                    Video = item.Video,
                    Vote_Average = item.Vote_Average,
                    Vote_Count = item.Vote_Count,
                    Ooverview = item.Overview
                }));
        }

        [RelayCommand]
        private async Task Detalle(ValoratedMovieDTO movie)
        {
            var uri = $"{nameof(PeliculasValoradasDetailPage)}?id={movie.Id}";
            await Shell.Current.GoToAsync(uri);
        }

    }
}
