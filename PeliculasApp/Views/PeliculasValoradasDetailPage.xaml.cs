using PeliculasApp.ViewModels;

namespace PeliculasApp.Views;

public partial class PeliculasValoradasDetailPage : ContentPage
{
	public PeliculasValoradasDetailPage(ValoradasDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

    }
}