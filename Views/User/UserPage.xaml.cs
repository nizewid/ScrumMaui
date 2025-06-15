using ScrumMaui.ViewModels;

namespace ScrumMaui.Views.User;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
        BindingContext = new UserViewModel();
	}
    private async void OnShowDataClicked(object sender, EventArgs e)
    {
        string userName = UsernameEntry.Text;
        string role = RoleEntry.Text;
        bool isScrumMaster = IsScrumMasterSwitch.IsToggled;

        await DisplayAlert("Datos Usuario",
            $"Nombre: {userName}\nRol: {role}\nScrum Master: {(isScrumMaster ? "Sí" : "No")}",
            "OK");
    }
}