using CommunityToolkit.Mvvm.ComponentModel;

namespace PeliculasApp.DTOs
{
    public partial class ValoratedMovieDTO : ObservableObject
    {
        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public bool adult;
        [ObservableProperty]
        public string backdrop_Path;
        [ObservableProperty]
        public string original_Language;
        [ObservableProperty]
        public string original_Title;
        [ObservableProperty]
        public string ooverview;
        [ObservableProperty]
        public double popularity;
        [ObservableProperty]
        public string poster_Path;
        [ObservableProperty]
        public string release_Date;
        [ObservableProperty]
        public string title;
        [ObservableProperty]
        public bool video;
        [ObservableProperty]
        public double vote_Average;
        [ObservableProperty]
        public int vote_Count;
    }
}
