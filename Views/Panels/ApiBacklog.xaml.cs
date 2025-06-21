using ScrumMaui.ViewModels;

namespace ScrumMaui.Views.Panels;

public partial class ApiBacklog : ContentPage
{
    private LoginViewModel loginViewModel = new LoginViewModel();
    public ApiBacklog(string token)
	{
		InitializeComponent();
        BindingContext = loginViewModel;
        CargarLista(token);
    }
    private async void CargarLista(string token)
    {
        if (token == "")
        {
            lblAvisos.Text = "Sin acceso";
        }
        else
        {
            await loginViewModel.CargarListaBacklog(token);
        }
    }

    private void btnVolver_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}