using ScrumMaui.Models;
using ScrumMaui.ViewModels;

namespace ScrumMaui.Views.Panels;

public partial class BdBacklog : ContentPage
{

    BdViewModel bdViewModel = new BdViewModel();

    private TaskModel tareaLocalSeleccionada;
    public BdBacklog()
	{
		InitializeComponent();

        BindingContext = bdViewModel;
        CargarLista();
    }

    private async Task CargarLista()
    {
        await bdViewModel.CargarListaDesdeBDAsync();
        SwitchBotones(false);
    }


    private void SwitchBotones(bool on)
    {
        btnBorrar.IsEnabled = on;
        btnModificar.IsEnabled = on;
    }


    private async void btnFiltrar_Clicked(object sender, EventArgs e)
    {
        await bdViewModel.GetTareasFiltroAsync(txtCodigoTarea.Text, txtNombreTarea.Text);
    }


    private async void btnNuevo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BdNewTask());
        await CargarLista();
    }


    private async void btnModificar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BdModifTask(tareaLocalSeleccionada));
        await CargarLista();
    }

    private async void btnBorrar_Clicked(object sender, EventArgs e)
    {
        bool resul = await DisplayAlert("Eliminar registro", "Se eliminará la Tarea " + tareaLocalSeleccionada.Name + " ¿Conforme?", "SI", "NO");
        if (resul)
        {
            await bdViewModel.DeleteBdSqLiteTareaAsync(tareaLocalSeleccionada);
            await CargarLista();
        }
    }

    private async void collViewListaBacklog_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TaskModel? tareaSel = e.CurrentSelection.FirstOrDefault() as TaskModel;
        if (tareaSel != null)
        {
            tareaLocalSeleccionada = tareaSel;
            SwitchBotones(true);
            await DisplayAlert("Se ha seleccionado", tareaSel.Name, "OK");
        }
    }
    private async void btnInicializar_Clicked(object sender, EventArgs e)
    {
        bool resul = await DisplayAlert("Inicializar BD", "Se inicializará la BD y se eliminarán todos los registros ¿Conforme?", "SI", "NO");
        if (resul)
        {
            await bdViewModel.InicializarBd();
            CargarLista();
        }
    }

    private async void btnCargar_Clicked(object sender, EventArgs e)
    {
        bool resul = await DisplayAlert("Cargar BD", "Se cargarán  registros desde el repositorio local ¿Conforme?", "SI", "NO");
        if (resul)
        {
            await bdViewModel.CargaInicialBd();
            CargarLista();
        }
    }
}