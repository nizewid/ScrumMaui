using ScrumMaui.Data;

namespace ScrumMaui.Views.Panels;

public partial class WebTaskList : ContentPage
{
    public WebTaskList()
    {
        InitializeComponent();
        MostrarHTML();
    }

    private async void MostrarHTML()
    {
        var tasks = await ScrumData.GetBacklogList();

        string html = "<html><body><h2>Listado de Tareas</h2><ul>";

        foreach (var task in tasks)
        {
            html += $"<li><b>{task.TaskCode}</b> - {task.Name} ({task.TaskType})</li>";
        }

        html += "</ul></body></html>";

        webTasks.Source = new HtmlWebViewSource { Html = html };
    }
}
