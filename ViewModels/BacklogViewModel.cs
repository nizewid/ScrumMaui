using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ScrumMaui.Data;
using ScrumMaui.Models;

namespace ScrumMaui.ViewModels
{
    public class BacklogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Models.Task> BacklogList { get; set; }

        public ICommand SearchTaskCommand { get; }

        public BacklogViewModel()
        {
            BacklogList = new ObservableCollection<Models.Task>();
            _ = LoadBacklogList("");
            SearchTaskCommand = new Command<string>(async (param) => await ExecuteSearch(param));
        }

        private async System.Threading.Tasks.Task LoadBacklogList(string taskNameFilter)
        {
            try
            {
                List<Models.Task> taskList = await ScrumData.GetBacklogList();

                if (!string.IsNullOrWhiteSpace(taskNameFilter))
                {
                    taskList = taskList
                        .Where(t => t.Name.ToLower().Contains(taskNameFilter.ToLower()))
                        .ToList();
                }

                foreach (var t in taskList)
                {
                    t.EndDateText = t.EndDate?.ToString("dd/MM/yyyy") ?? string.Empty;
                    t.PlannedDateText = t.PlannedDate?.ToString("dd/MM/yyyy") ?? string.Empty;
                    t.AssignedDateText = t.AssignedDate?.ToString("dd/MM/yyyy") ?? string.Empty;
                }

                BacklogList.Clear();
                foreach (var t in taskList)
                {
                    BacklogList.Add(t);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Backlog] Error: {ex.Message}");
            }
        }

        private async System.Threading.Tasks.Task ExecuteSearch(string searchText)
        {
            await LoadBacklogList(searchText);
        }
    }
}