using ScrumMaui.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumMaui.Data
{
    public class BdScrumSQLite
    {
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<TaskModel>();
        }

        public async Task<List<TaskModel>> GetTareasAllAsync()
        {
            await Init();
            return await Database.Table<TaskModel>().ToListAsync();
        }

        public async Task<List<TaskModel>> GetTareasFiltroAsync(string codigoTarea, string nombreTarea)
        {
            await Init();
            codigoTarea = codigoTarea == null ? "" : codigoTarea;
            nombreTarea = nombreTarea == null ? "" : nombreTarea;
            return await Database.Table<TaskModel>().Where(i => i.TaskCode.Contains(codigoTarea)).Where(c => c.Name.Contains(nombreTarea)).ToListAsync();
        }

        public async Task<TaskModel> GetTareaByIdAsync(int id)
        {
            await Init();
            return await Database.Table<TaskModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddTareaAsync(TaskModel tarea)
        {
            await Init();
            return await Database.InsertAsync(tarea);
        }
        public async Task<int> UpdateTareaAsync(TaskModel tarea)
        {
            await Init();
            return await Database.UpdateAsync(tarea);
        }

        public async Task<int> DeleteTareaAsync(TaskModel tarea)
        {
            await Init();
            return await Database.DeleteAsync(tarea);
        }

    }
}
