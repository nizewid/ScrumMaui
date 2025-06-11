namespace ScrumMaui.Views.User;

public partial class Locations : ContentPage
{
	public Locations()
	{
		InitializeComponent();
	}
	private void btnUser01_Clicked(object sender, EventArgs e)
    {
        imgUser.Source = "user_01.png";
    }
	private void btnUser02_Clicked(object sender, EventArgs e)
    {
        imgUser.Source = "user_02.png";
    }
    private void btnUser03_Clicked(object sender, EventArgs e)
    {
        imgUser.Source = "user_03.png";
    }
    private void btnUser04_Clicked(object sender, EventArgs e)
    {
        imgUser.Source = "user_04.png";
    }
}