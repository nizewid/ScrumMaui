using ScrumMaui.Models;
using ScrumMaui.ViewModels;
using System.Diagnostics;

namespace ScrumMaui.Views.Panels;

public partial class Backlog : ContentPage
{
    private BacklogViewModel backlogViewModel = new BacklogViewModel();

    public Backlog()
    {
        InitializeComponent();
        IniciarCancelarActivityIndicator(true, true);
        BindingContext = backlogViewModel;
        IniciarCancelarActivityIndicator(false, false);
    }

    private void IniciarCancelarActivityIndicator(bool isRunning, bool isVisible)
    {
        activityIndicator.IsRunning = isRunning;
        activityIndicator.IsVisible = isVisible;
    }

    private void SearchBarTasks_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (((SearchBar)sender).SearchCommand?.CanExecute(e.NewTextValue) == true)
        {
            ((SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
        }
    }

    private async void collViewListaBacklog_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("Elemento seleccionado: " + e.CurrentSelection.Count);
        TaskModel? selectedTask = e.CurrentSelection.FirstOrDefault() as TaskModel;
        Debug.WriteLine("Elemento seleccionado: " + selectedTask?.Name);
        if (selectedTask != null)
        {
            bool confirm = await DisplayAlert("¿Eliminar la Tarea?", selectedTask.Name, "SI", "NO");
            if (confirm)
            {
                bool ok = await EliminarTarea(selectedTask.Id);
                if (ok)
                {
                    await DisplayAlert(selectedTask.Name, "La tarea se eliminó correctamente", "OK");
                    await ActualizarDatosLista();
                }
            }
        }
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        await ActualizarDatosLista();
    }

    private async Task ActualizarDatosLista()
    {
        IniciarCancelarActivityIndicator(true, true);
        await backlogViewModel.LoadTaskList("");
        IniciarCancelarActivityIndicator(false, false);
    }

    private async Task<bool> EliminarTarea(int id)
    {
        return await backlogViewModel.DeleteTask(id);
    }
}