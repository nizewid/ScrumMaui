using ScrumMaui.Models;
using ScrumMaui.ViewModels;

namespace ScrumMaui.Views.Panels;

public partial class BdModifTask : ContentPage
{
	private TaskModel tareaInicial;
	BdViewModel bdViewModel = new BdViewModel();
    public BdModifTask(TaskModel tareaInicial)
	{
		InitializeComponent();
		tareaInicial = new TaskModel();
		LoadInitialData();
    }
    private void LoadInitialData()
    {
        txtCodigoTarea.Text = tareaInicial.TaskCode;
        txtNombreTarea.Text = tareaInicial.Name;
        txtNombreTareaPadre.Text = tareaInicial.ParentTaskName;
        txtDescripcion.Text = tareaInicial.Description;
        datePicFechaPlanificacion.Date = (DateTime)(tareaInicial.PlannedDate == null ? DateTime.Now : tareaInicial.PlannedDate); ;
        foreach (var item in pickerTipoTarea.Items)
        {
            if (item == tareaInicial.TaskType)
            {
                pickerTipoTarea.SelectedItem = item;
            }
        }
        foreach (var item in pickerIcono.Items)
        {
            if (item == tareaInicial.TypeIcon)
            {
                pickerIcono.SelectedItem = item;
            }
        }
    }

    private async void btnAceptar_Clicked(object sender, EventArgs e)
    {
        if (ValidarDatosEntrada())
        {
            tareaInicial.TaskCode = txtCodigoTarea.Text;
            tareaInicial.Name = txtNombreTarea.Text;
            tareaInicial.ParentTaskName= txtNombreTareaPadre.Text;
            tareaInicial.Description = txtDescripcion.Text;
            tareaInicial.PlannedDate = datePicFechaPlanificacion.Date;
            tareaInicial.TaskType = pickerTipoTarea.SelectedItem.ToString();
            tareaInicial.TypeIcon = pickerIcono.SelectedItem.ToString();

            bool ok = await bdViewModel.UpdateBdSqLiteTareaAsync(tareaInicial);
            if (ok)
            {
                await DisplayAlert("Modificar Tarea", "La tarea se modificó correctamente", "Ok");
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