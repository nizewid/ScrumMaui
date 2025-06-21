using ScrumMaui.Models;
using ScrumMaui.ViewModels;

namespace ScrumMaui.Views.Panels;

public partial class BdNewTask : ContentPage
{
    BdViewModel bdViewModel = new BdViewModel();
    public BdNewTask()
	{
		InitializeComponent();
	}
    private async void btnAceptar_Clicked(object sender, EventArgs e)
    {
        if (ValidarDatosEntrada())
        {
            TaskModel nuevaTarea = new TaskModel();
            nuevaTarea.TaskCode = txtCodigoTarea.Text;
            nuevaTarea.Name = txtNombreTarea.Text;
            nuevaTarea.ParentTaskName = txtNombreTareaPadre.Text;
            nuevaTarea.Description = txtDescripcion.Text;
            nuevaTarea.Status = "Creada";
            nuevaTarea.PlannedDate = datePicFechaPlanificacion.Date;
            nuevaTarea.TaskType = pickerTipoTarea.SelectedItem.ToString();
            nuevaTarea.TypeIcon = pickerIcono.SelectedItem.ToString();

            bool ok = await bdViewModel.AddBdSqLiteTareaAsync(nuevaTarea);
            if (ok)
            {
                await DisplayAlert("Crear Tarea", "La tarea se creó correctamente", "Ok");
                Navigation.PopAsync();
            }
        }
    }

    private bool ValidarDatosEntrada()
    {
        bool ok = true;
        string msg = "";

        if (txtCodigoTarea.Text == null || txtCodigoTarea.Text.Length < 8)
        {
            msg = "El código de tarea debe tener al menos 8 caracteres" + Environment.NewLine;
        }
        if (txtNombreTarea.Text == null || txtNombreTarea.Text.Length < 5)
        {
            msg += "El Nombre de tarea debe tener al menos 5 caracteres" + Environment.NewLine;
        }
        if (txtNombreTareaPadre.Text == null || txtNombreTareaPadre.Text.Length < 5)
        {
            msg += "La Tarea Padre debe tener al menos 5 caracteres" + Environment.NewLine;
        }
        if (txtDescripcion.Text == null || txtDescripcion.Text.Length < 1)
        {
            msg += "La Descripción no puede quedar en blanco" + Environment.NewLine;
        }

        if (msg != "")
        {
            DisplayAlert("Errores de validación", msg, "Ok");
            ok = false;
        }

        return ok;
    }

    private void btnVolver_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}