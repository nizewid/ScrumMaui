using ScrumMaui.Models;
using ScrumMaui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScrumMaui.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<TaskModel> ListaBacklog { get; set; }
        public LoginViewModel()
        {
            ListaBacklog = new ObservableCollection<TaskModel>();
        }

        public async Task<string> LoginUsuario(string nombreUsuario, string password)
        {
            string token = await LoginServiceApi.LoginUsuario(nombreUsuario, password);
            return token;
        }

        public async Task CargarListaBacklog(string token)
        {
            try
            {
                List<TaskModel> listaTareas = await LoginServiceApi.GetListaTareas(token);

                string cadJson = JsonSerializer.Serialize(listaTareas);

                ListaBacklog.Clear();
                foreach (TaskModel t in listaTareas)
                {
                    ListaBacklog.Add(t);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
