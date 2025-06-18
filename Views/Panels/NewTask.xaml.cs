using Microsoft.Maui.Controls;
using ScrumMaui.Models;
using ScrumMaui.ViewModels;

namespace ScrumMaui.Views.Panels;

[QueryProperty(nameof(TaskName), "taskName")]
[QueryProperty(nameof(TaskType), "taskType")]
public partial class NewTask : ContentPage
{
    private BacklogViewModel backlogViewModel = new BacklogViewModel();

    public string TaskName
    {
        set => AssignTaskName(value);
    }

    public string TaskType
    {
        set => AssignTaskType(value);
    }

    public NewTask()
    {
        InitializeComponent();
    }

    private void AssignTaskName(string name)
    {
        txtTaskName.Text = Uri.UnescapeDataString(name ?? "");
    }

    private void AssignTaskType(string type)
    {
        int index = pickerTaskType.ItemsSource?.IndexOf(type) ?? -1;
        if (index >= 0) pickerTaskType.SelectedIndex = index;
    }

    private async void btnAccept_Clicked(object sender, EventArgs e)
    {
        if (IsValidToSave())
        {
            var task = new TaskModel
            {
                TaskCode = txtTaskCode.Text,
                Name = txtTaskName.Text,
                Description = txtDescription.Text,
                ParentTaskName = txtParentTaskName.Text,
                PlannedDate = datePlannedDate.Date,
                TaskType = pickerTaskType.SelectedItem?.ToString(),
                TypeIcon = pickerIcon.SelectedItem?.ToString(),
                Status = "Created"
            };

            bool ok = await backlogViewModel.AddTask(task);

            if (ok)
            {
                await DisplayAlert("Crear Tarea", "La tarea se creó correctamente", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await DisplayAlert("Error", "Hubo un problema al guardar la tarea.", "Cerrar");
            }
        }
    }

    private bool IsValidToSave()
    {
        string msg = "";

        if (string.IsNullOrWhiteSpace(txtTaskCode.Text) || txtTaskCode.Text.Length < 8)
            msg += "- El código de la tarea debe tener al menos 8 caracteres.\n";

        if (string.IsNullOrWhiteSpace(txtTaskName.Text) || txtTaskName.Text.Length < 5)
            msg += "- El nombre de la tarea debe tener al menos 5 caracteres.\n";

        if (string.IsNullOrWhiteSpace(txtParentTaskName.Text) || txtParentTaskName.Text.Length < 5)
            msg += "- La tarea padre debe tener al menos 5 caracteres.\n";

        if (string.IsNullOrWhiteSpace(txtDescription.Text))
            msg += "- La descripción no puede estar vacía.\n";

        if (!string.IsNullOrWhiteSpace(msg))
        {
            DisplayAlert("Errores de validación", msg, "OK");
            return false;
        }

        return true;
    }
}
