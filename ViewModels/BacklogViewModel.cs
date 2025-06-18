using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ScrumMaui.Data;
using ScrumMaui.Models;
using ScrumMaui.Services;

namespace ScrumMaui.ViewModels
{
    public class BacklogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<TaskModel> TaskList { get; set; }

        public ICommand SearchTaskCommand { get; private set; }

        public BacklogViewModel()
        {
            TaskList = new ObservableCollection<TaskModel>();
            _ = LoadTaskList("");
            SearchTaskCommand = new Command<string>(async (string param) => await ExecuteSearch(param));
        }

        public async Task LoadTaskList(string searchName)
        {
            try
            {
                List<TaskModel>? tasks = await ServiceApi.GetTaskList();

                // Si API devuelve null o vacía, carga local
                if (tasks == null || !tasks.Any())
                {
                    tasks = await ScrumData.GetBacklogList();
                }

                if (!string.IsNullOrEmpty(searchName))
                {
                    tasks = tasks.Where(t => t.Name != null &&
                                             t.Name.ToLower().Contains(searchName.ToLower()))
                                 .ToList();
                }

                foreach (var task in tasks)
                {
                    // Adaptamos las fechas en formato texto
                    task.PlannedDateText = task.PlannedDate?.ToString("dd/MM/yyyy");
                    task.AssignedDateText = task.AssignedDate?.ToString("dd/MM/yyyy");
                    task.EndDateText = task.EndDate?.ToString("dd/MM/yyyy");
                }

                TaskList.Clear();
                foreach (var task in tasks)
                {
                    TaskList.Add(task);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar tareas: {ex.Message}");
            }
        }

        public async Task ExecuteSearch(string query)
        {
            await LoadTaskList(query);
        }

        public async Task<bool> AddTask(TaskModel newTask)
        {
            return await ServiceApi.AddTask(newTask);
        }

        public async Task<bool> DeleteTask(int id)
        {
            return await ServiceApi.DelTask(id);
        }
    }
}