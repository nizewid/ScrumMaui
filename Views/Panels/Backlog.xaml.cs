using ScrumMaui.ViewModels;

namespace ScrumMaui.Views.Panels;

public partial class Backlog : ContentPage
{
	public Backlog()
	{
		InitializeComponent();
        BindingContext = new BacklogViewModel();
    }
}