using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumMaui.Models
{
    public static class TaskTypes
    {
        public static string Epic => "Épica";
        public static string UserStory => "Historia de Usuario";
        public static string FinalTask => "Tarea Final";
        public static string Incident => "Incidencia";
    }

    public static class TaskStatuses
    {
        public static string Created => "Creado";
        public static string InSprint => "En Sprint";
        public static string Assigned => "Asignado";
        public static string InProgress => "En Progreso";
        public static string Completed => "Realizado";
        public static string Verified => "Verificado";
        public static string Finished => "Finalizado";
    }

    public class Task
    {
        public string? TaskCode { get; set; }
        public string? TaskType { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ParentTaskCode { get; set; }
        public string? ParentTaskName { get; set; }
        public string? Status { get; set; }
        public DateTime? PlannedDate { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? PlannedDateText { get; set; }
        public string? AssignedDateText { get; set; }
        public string? EndDateText { get; set; }
        public string? AssignedUser { get; set; }
        public string? Notes { get; set; }
        public string? TypeIcon { get; set; }
        public string? Avatar { get; set; }
    }


}
