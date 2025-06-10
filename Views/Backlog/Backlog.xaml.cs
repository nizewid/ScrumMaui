using ScrumMaui.ViewModels;
namespace ScrumMaui.Panels;

public partial class Backlog : ContentPage
{
    public Backlog()
    {
        InitializeComponent();
        BindingContext = new BacklogViewModel();
    }

    private void SearchBarTasks_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (((SearchBar)sender).SearchCommand?.CanExecute(e.NewTextValue) == true)
        {
            ((SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
        }
    }
}