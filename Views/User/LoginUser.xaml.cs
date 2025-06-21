using ScrumMaui.ViewModels;
using ScrumMaui.Views.Panels;

namespace ScrumMaui.Views.User;

public partial class LoginUser : ContentPage
{
    LoginViewModel loginViewModel = new LoginViewModel();
    string localToken = "";
    public LoginUser()
	{
		InitializeComponent();
	}
    private async void btnAcceder_Clicked(object sender, EventArgs e)
    {
        if (DatosCorrectos())
        {
            localToken = await loginViewModel.LoginUsuario(txtUsuario.Text, txtPassword.Text);
            if (localToken == "")
            {
                lblMsgAcceso.Text = "Acceso denegado";
            }
            else
            {
                lblMsgAcceso.Text = "Acceso correcto";
                contenedorDatos.IsVisible = false;
            }
        }
    }

    private bool DatosCorrectos()
    {
        bool ok = true;

        if (txtUsuario.Text == null || txtUsuario.Text == "")
        {
            ok = false;
        }
        if (txtPassword.Text == null || txtPassword.Text == "")
        {
            ok = false;
        }

        if (!ok)
        {
            lblMsgAcceso.Text = "Se requiere cumplimentar los datos de entrada";
        }

        return ok;
    }

    private async void btnVerLista_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ApiBacklog(localToken));
    }
}