using System;
using System.Collections.Generic;
using System.ComponentModel;
using ScrumMaui.Data;
using ScrumMaui.Models;

namespace ScrumMaui.ViewModels
{
    public class BacklogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Models.Task> ListBacklog { get; set; }

        public BacklogViewModel()
        {
            ListBacklog = new List<Models.Task>();
            LoadListBacklog();
        }

        private void LoadListBacklog()
        {
            ListBacklog = ScrumData.GetBacklogList();

            foreach (Models.Task t in ListBacklog)
            {
                t.EndDateText = string.Format("{0:dd/MM/yyyy}", t.EndDate);
                t.PlannedDateText = string.Format("{0:dd/MM/yyyy}", t.PlannedDate);
                t.AssignedDateText = string.Format("{0:dd/MM/yyyy}", t.AssignedDate);
            }
        }
    }
}
