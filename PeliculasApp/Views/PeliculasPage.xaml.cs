using PeliculasApp.ViewModels;

namespace PeliculasApp.Views;

public partial class PeliculasPage : ContentPage
{
	public PeliculasPage(PeliculasViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}