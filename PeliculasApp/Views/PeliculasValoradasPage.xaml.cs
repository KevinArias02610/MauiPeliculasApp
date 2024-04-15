using PeliculasApp.ViewModels;

namespace PeliculasApp.Views
{
    public partial class PeliculasValoradasPage : ContentPage
    {
        public PeliculasValoradasPage(ValoradasViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }
    }
}