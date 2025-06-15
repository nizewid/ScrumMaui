using UserModel = ScrumMaui.Models.User;
namespace ScrumMaui.Views.Spring;

public partial class SpringPanel : ContentPage
{
	public SpringPanel()
	{
		InitializeComponent();
	}

    private async void btnNewTask_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//backlog_root/backlog_new");
    }

    private async void btnNewIncidence_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//backlog_root/backlog_new?taskName=Ventas&taskType=Epica");
    }
    private async void btnNewUser_Clicked(object sender, EventArgs e)
    {
        UserModel demoUser = new UserModel()
        {
            UserName = "Demo User",
            Role = "Developer",
            IsScrumMaster = false
        };
        Dictionary<string, object> navigationParam = new Dictionary<string, object>();
        navigationParam.Add("user", demoUser);
        await Shell.Current.GoToAsync("//user_root/user_data", navigationParam);
    }
}