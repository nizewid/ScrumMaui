using ScrumMaui.Data;
using ScrumMaui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumMaui.ViewModels
{
    public class BdViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<TaskModel> ListaBacklogBd { get; set; }

        private BdScrumSQLite bdSqLite;


        public BdViewModel()
        {
            bdSqLite = new BdScrumSQLite();
            ListaBacklogBd = new ObservableCollection<TaskModel>();
        }

        #region Llamadas a métodos BD SQLite

        public async Task CargarListaDesdeBDAsync()
        {
            try
            {
                var lstTareas = await bdSqLite.GetTareasAllAsync();
                InicializarListaObservable(lstTareas);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public async Task GetTareasFiltroAsync(string codigoTarea, string nombreTarea)
        {
            try
            {
                var lstTareas = await bdSqLite.GetTareasFiltroAsync(codigoTarea, nombreTarea);
                InicializarListaObservable(lstTareas);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void InicializarListaObservable(List<TaskModel> listaTareas)
        {
            ListaBacklogBd.Clear();
            foreach (TaskModel t in listaTareas)
            {
                ListaBacklogBd.Add(t);
            }
        }

        public async Task<bool> AddBdSqLiteTareaAsync(TaskModel nuevaTarea)
        {
            bool ok = false;
            try
            {
                int resul = await bdSqLite.AddTareaAsync(nuevaTarea);
                if (resul == 1)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return ok;
        }

        public async Task<bool> DeleteBdSqLiteTareaAsync(TaskModel tarea)
        {
            bool ok = false;
            try
            {
                int resul = await bdSqLite.DeleteTareaAsync(tarea);
                if (resul == 1)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return ok;
        }

        public async Task<bool> UpdateBdSqLiteTareaAsync(TaskModel tarea)
        {
            bool ok = false;
            try
            {
                int resul = await bdSqLite.UpdateTareaAsync(tarea);
                if (resul == 1)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return ok;
        }

        public async Task CargaInicialBd()
        {
            try
            {
                List<TaskModel> lstTareas = await ScrumData.GetBacklogList();
                foreach (TaskModel tar in lstTareas)
                {
                    await bdSqLite.AddTareaAsync(tar);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task InicializarBd()
        {
            try
            {
                var lstTareas = await bdSqLite.GetTareasAllAsync();
                foreach (TaskModel tar in lstTareas)
                {
                    await bdSqLite.DeleteTareaAsync(tar);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
