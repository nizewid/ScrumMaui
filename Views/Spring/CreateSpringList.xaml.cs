using ScrumMaui.ViewModels;
using ScrumMaui.Models;

namespace ScrumMaui.Views.Spring;

public partial class CreateSpringList : ContentPage
{
    private string codigoEnMovimiento = "";
    ScrumViewModel scrumVistaModelo = new ScrumViewModel();
    public CreateSpringList()
	{
		InitializeComponent();
        BindingContext = scrumVistaModelo;
    }

    private void IniciarMoverTarea_DragStarting(object sender, DragStartingEventArgs e)
    {
        DragGestureRecognizer gesto = (DragGestureRecognizer)sender;
        codigoEnMovimiento = gesto.DragStartingCommandParameter.ToString();
    }

    private void FinalizarMoverTarea_Drop(object sender, DropEventArgs e)
    {
        if (codigoEnMovimiento != "")
        {
            Models.Task tareaMueve = scrumVistaModelo.TaskListBacklog.FirstOrDefault(t => t.TaskCode.Equals(codigoEnMovimiento));
            if (tareaMueve != null)
            {
                scrumVistaModelo.TaskListSpring.Add(tareaMueve);
                scrumVistaModelo.TaskListBacklog.Remove(tareaMueve);
            }
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopModalAsync();
    }
}
