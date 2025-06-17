namespace ScrumMaui.Views.Info;

public partial class Help01Scrum : ContentPage
{
	public Help01Scrum()
	{
		InitializeComponent();
	}
    private void btnArtefactos_Clicked(object sender, EventArgs e)
    {
        panelArtefactos.IsVisible = !panelArtefactos.IsVisible;
    }

    private void btnUsuarios_Clicked(object sender, EventArgs e)
    {
        panelUsuarios.IsVisible = !panelUsuarios.IsVisible;
    }

    private void btnElementos_Clicked(object sender, EventArgs e)
    {
        panelElementos.IsVisible = !panelElementos.IsVisible;
    }
    private void btnBlueTheme_Clicked(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> listaDiccionarios = Application.Current.Resources.MergedDictionaries;
        if (listaDiccionarios != null)
        {
            listaDiccionarios.Clear();
            listaDiccionarios.Add(new Themes.BlueTheme());
        }
    }
    private void btnWhiteTheme_Clicked(object sender, EventArgs e)
    {

        ICollection<ResourceDictionary> listaDiccionarios = Application.Current.Resources.MergedDictionaries;
        if (listaDiccionarios != null)
        {
            listaDiccionarios.Clear();
            listaDiccionarios.Add(new Themes.WhiteTheme());
        }
    }
}