using Microsoft.Maui.Controls;

namespace ScrumMaui.Views.Panels;

[QueryProperty(nameof(NombreTarea), "taskName")]
[QueryProperty(nameof(TipoTarea), "taskType")]
public partial class NewTask : ContentPage
{
    public NewTask()
    {
        InitializeComponent();
    }

    public string NombreTarea
    {
        set => AsignTaskName(value);
    }

    public string TipoTarea
    {
        set => AsignTaskType(value);
    }

    private void AsignTaskName(string name)
    {
        txtTaskName.Text = Uri.UnescapeDataString(name ?? "");
    }

    private void AsignTaskType(string type)
    {
        txtTaskType.Text = Uri.UnescapeDataString(type ?? "");
    }
}
