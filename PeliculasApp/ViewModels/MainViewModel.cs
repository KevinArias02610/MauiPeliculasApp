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
    public partial class MainViewModel : ObservableObject
    {
        private readonly PeliculaDbContext _dbContext;

        [ObservableProperty]
        private ObservableCollection<MovieDTO> listaPeliculas = new();

        public MainViewModel(PeliculaDbContext context)
        {
            _dbContext = context;
            MainThread.BeginInvokeOnMainThread(new Action(async () => await ObtenerPeliculas()));
        }

        public async Task ObtenerPeliculas()
        {
            FormatLenguajes formatLenguajes = new();
            var lista = await _dbContext.Movies.ToListAsync();
            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    ListaPeliculas.Add(new MovieDTO
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
                    });
                }
            }
            else
            {
                MoviesService moviesService = new();
                var resp = await moviesService.ObtenerPeliculas();
                foreach (var item in resp)
                {
                    _dbContext.Movies.Add(new Movie
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
                await ObtenerPeliculas();
            }
        }

        [RelayCommand]
        private async Task Editar(MovieDTO movie)
        {
            var uri = $"{nameof(PeliculasPage)}?id={movie.Id}";
            await Shell.Current.GoToAsync(uri);
        }
    }
}
