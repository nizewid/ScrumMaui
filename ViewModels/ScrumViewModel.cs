using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrumMaui.Data;
using ScrumMaui.Models;

namespace ScrumMaui.ViewModels
{
    public class ScrumViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Models.Task> taskListBacklog;
        public ObservableCollection<Models.Task> TaskListBacklog
        {
            get { return taskListBacklog; }
            set
            {
                taskListBacklog = value;
                OnPropertyChanged(nameof(TaskListBacklog));
            }
        }

        private ObservableCollection<Models.Task> taskListSpring;
        public ObservableCollection<Models.Task> TaskListSpring
        {
            get { return taskListSpring; }
            set
            {
                taskListSpring = value;
                OnPropertyChanged(nameof(TaskListSpring));
            }
        }
        public ScrumViewModel()
        {
            LoadListBacklog();
            LoadListSpring();
        }

        private async void LoadListBacklog()
        {
            TaskListBacklog = new ObservableCollection<Models.Task>();
            List<Models.Task> backlogList = await ScrumData.GetBacklogList();
            foreach (var item in backlogList)
            {
                TaskListBacklog.Add(item);
            }
        }
        private void LoadListSpring()
        {
            taskListSpring = new ObservableCollection<Models.Task>();
        }
        protected virtual void OnPropertyChanged(string nameOfPropertyChanged)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(nameOfPropertyChanged));
            }
        }

    }
}
