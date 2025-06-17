namespace ScrumMaui.Views.User;

public partial class TeamWork : ContentPage
{
	public TeamWork()
	{
		InitializeComponent();
	}

    private void btnAssign_Clicked(object sender, EventArgs e)
    {
        Resources["BaseProductOwnerFrame"] = Resources["ProductOwnerFrame"];
        Resources["BaseScrumMasterFrame"] = Resources["ScrumMasterFrame"];
        Resources["BaseEquipoFrame"] = Resources["EquipoFrame"];

        Resources["labelBaseProductOwner"] = Resources["labelProductOwner"];
        Resources["labelBaseScrumMaster"] = Resources["labelScrumMaster"];
        Resources["labelBaseEquipo"] = Resources["labelEquipo"];
    }
}