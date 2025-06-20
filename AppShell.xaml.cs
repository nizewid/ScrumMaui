﻿using ScrumMaui.Views.Info;
using ScrumMaui.Views.Panels;
using ScrumMaui.Views.Spring;
using ScrumMaui.Views.User;

namespace ScrumMaui
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            
        }

        void RegisterRoutes()
        {
            Routes.Add("home", typeof(MainPage));
            Routes.Add("login", typeof(LoginUser));

            Routes.Add("user_data", typeof(UserPage));
            Routes.Add("team", typeof(UserEquipment));
            Routes.Add("assign", typeof(Locations));

            Routes.Add("backlog_panel", typeof(WebTaskList));
            Routes.Add("backlog_new_Task", typeof(NewTask));
            Routes.Add("backlog_show_task", typeof(ShowTask));
            Routes.Add("backlog_database", typeof(BdBacklog));

            Routes.Add("sprint_new", typeof(NewSpring));
            Routes.Add("sprint_panel", typeof(SpringPanel));
            Routes.Add("sprint_daily", typeof(Help01Scrum));
            Routes.Add("sprint_retrospective", typeof(Help01Scrum));

            Routes.Add("help", typeof(Help01Scrum));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
