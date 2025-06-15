using ScrumMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ScrumMaui.Models.Task;

namespace ScrumMaui.Data
{
    public static class ScrumData
    {
        public static async System.Threading.Tasks.Task<List<Models.Task>> GetBacklogList()
        {
            List<Task> backlog = new List<Task>
               {
                   new Task
                   {
                       TaskCode = "DEMO-0001",
                       TaskType = TaskTypes.Epic,
                       Name = "Gestión de seguridad y acceso",
                       ParentTaskName = "Raíz",
                       Description = "Creación de los elementos necesarios para gestionar la seguridad de la app y el acceso a la misma.",
                       PlannedDate = DateTime.Now.AddDays(130),
                       Status = TaskStatuses.Created,
                       TypeIcon = "scrumepica.png"
                   },
                   new Task
                   {
                       TaskCode = "DEMO-0002",
                       TaskType = TaskTypes.UserStory,
                       Name = "Mantenimiento de usuarios",
                       ParentTaskName = "Gestión de seguridad y acceso",
                       Description = "Permitir añadir, eliminar y modificar usuarios. Lista de usuarios con búsqueda.",
                       ParentTaskCode = "DEMO-0001",
                       PlannedDate = DateTime.Now.AddDays(30),
                       Status = TaskStatuses.Created,
                       TypeIcon = "scrumhistoria.png"
                   },
                   new Task
                   {
                       TaskCode = "DEMO-0003",
                       TaskType = TaskTypes.FinalTask,
                       Name = "Listado de usuarios",
                       ParentTaskName = "Mantenimiento de usuarios",
                       Description = "Visualizar una lista con los usuarios registrados.",
                       ParentTaskCode = "DEMO-0002",
                       PlannedDate = DateTime.Now.AddDays(5),
                       Status = TaskStatuses.Created,
                       TypeIcon = "scrumtarea.png"
                   },
                   new Task
                   {
                       TaskCode = "DEMO-0004",
                       TaskType = TaskTypes.FinalTask,
                       Name = "Búsqueda de usuario",
                       ParentTaskName = "Mantenimiento de usuarios",
                       Description = "Permitir buscar un usuario por nombre o DNI.",
                       ParentTaskCode = "DEMO-0002",
                       PlannedDate = DateTime.Now.AddDays(8),
                       Status = TaskStatuses.Created,
                       TypeIcon = "scrumtarea.png"
                   },
                   new Task
                   {
                       TaskCode = "DEMO-0005",
                       TaskType = TaskTypes.FinalTask,
                       Name = "Nuevo usuario",
                       ParentTaskName = "Mantenimiento de usuarios",
                       Description = "Registrar un nuevo usuario.",
                       ParentTaskCode = "DEMO-0002",
                       PlannedDate = DateTime.Now.AddDays(9),
                       Status = TaskStatuses.Created,
                       TypeIcon = "scrumtarea.png"
                   },
                   new Task
                   {
                       TaskCode = "DEMO-0006",
                       TaskType = TaskTypes.FinalTask,
                       Name = "Eliminar usuario",
                       ParentTaskName = "Mantenimiento de usuarios",
                       Description = "Dar de baja un usuario.",
                       ParentTaskCode = "DEMO-0002",
                       PlannedDate = DateTime.Now.AddDays(12),
                       Status = TaskStatuses.Created,
                       TypeIcon = "scrumtarea.png"
                   },
                   new Task
                   {
                       TaskCode = "DEMO-0007",
                       TaskType = TaskTypes.FinalTask,
                       Name = "Modificar usuario",
                       ParentTaskName = "Mantenimiento de usuarios",
                       Description = "Modificar los datos de un usuario.",
                       ParentTaskCode = "DEMO-0002",
                       PlannedDate = DateTime.Now.AddDays(14),
                       Status = TaskStatuses.Created,
                       TypeIcon = "scrumtarea.png"
                   },
                   new Task
                   {
                       TaskCode = "DEMO-0008",
                       TaskType = TaskTypes.UserStory,
                       Name = "Mantenimiento de perfiles",
                       ParentTaskName = "Gestión de seguridad y acceso",
                       Description = "Permitir añadir, eliminar y modificar perfiles. Lista de perfiles con búsqueda.",
                       ParentTaskCode = "DEMO-0001",
                       PlannedDate = DateTime.Now.AddDays(20),
                       Status = TaskStatuses.Created,
                       TypeIcon = "scrumhistoria.png"
                   },
                   new Task
                   {
                       TaskCode = "DEMO-0009",
                       TaskType = TaskTypes.FinalTask,
                       Name = "Listado de perfiles",
                       ParentTaskName = "Mantenimiento de perfiles",
                       Description = "Visualizar una lista con los perfiles existentes.",
                       ParentTaskCode = "DEMO-0008",
                       PlannedDate = DateTime.Now.AddDays(24),
                       Status = TaskStatuses.Created,
                       TypeIcon = "scrumtarea.png"
                   },
                   new Task
                   {
                       TaskCode = "DEMO-0010",
                       TaskType = TaskTypes.FinalTask,
                       Name = "Búsqueda de perfil",
                       ParentTaskName = "Mantenimiento de perfiles",
                       Description = "Permitir buscar un perfil por su nombre.",
                       ParentTaskCode = "DEMO-0008",
                       PlannedDate = DateTime.Now.AddDays(26),
                       Status = TaskStatuses.Created,
                       TypeIcon = "scrumtarea.png"
                   }
               };
            return await System.Threading.Tasks.Task.FromResult(backlog);
        }
    }
}
