using ScrumMaui.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace ScrumMaui.Services
{
    public class ServiceApi
    {
        public static List<TaskModel> TaskList { get; private set; }
        private static JsonSerializerOptions serializerOptions;

        private static HttpClient conexionHttp;

        //private string urlWeb = ("https://localhost:7160");
        //se sutituye localhost por la ip que permite conectar al emulador android

        private static string urlWeb = ("http://192.168.0.29:5000");


        static ServiceApi()
        {
            HttpClientHandler insecureHandler = GetInsecureHandler();
            conexionHttp = new HttpClient(insecureHandler);
            conexionHttp.Timeout = TimeSpan.FromSeconds(25);
            conexionHttp.BaseAddress = new Uri(urlWeb);

            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        // This method must be in a class in a platform project, even if
        // the HttpClient object is constructed in a shared project.
        public static HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        public static async Task<List<TaskModel>> GetTaskList()
        {
            TaskList = new List<TaskModel>();

            try
            {
                Debug.WriteLine("🟡 [DEBUG] Llamando a la API...");
                Debug.WriteLine("🟡 [DEBUG] URL: " + urlWeb + "/api/Scrum");
                HttpResponseMessage response = await conexionHttp.GetAsync(urlWeb + "/api/Scrum");
                
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("🟢 [OK] Respuesta recibida: 200");
                    string respuesta = await response.Content.ReadAsStringAsync();
                    TaskList = JsonSerializer.Deserialize<List<TaskModel>>(respuesta, serializerOptions);
                }
                else
                {
                    TaskList = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("🔴 [ERROR] No se pudo conectar: " + ex);
                TaskList = null;
            }

            return TaskList;
        }
        public static async Task<TaskModel> GetTask(int id)
        {
            TaskModel task = null;
            try
            {
                HttpResponseMessage response = await conexionHttp.GetAsync(urlWeb + "/api/Scrum/" + id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var datoRespuesta = await response.Content.ReadAsStringAsync();
                    task = JsonSerializer.Deserialize<TaskModel>(datoRespuesta, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return task;
        }

        public static async Task<bool> AddTask(TaskModel newTask)
        {
            bool ok = false;
            try
            {
                string cadJsonTarea = JsonSerializer.Serialize(newTask, serializerOptions);
                StringContent contenidoHttpEnvio = new StringContent(cadJsonTarea, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await conexionHttp.PostAsync(urlWeb + "/api/Scrum", contenidoHttpEnvio);

                ok = response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return ok;
        }

        public static async Task<bool> ModifTask(TaskModel taskModif)
        {
            bool ok = false;
            try
            {
                string cadJsonTarea = JsonSerializer.Serialize(taskModif, serializerOptions);
                StringContent contenidoHttpEnvio = new StringContent(cadJsonTarea, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await conexionHttp.PutAsync(urlWeb + "/api/Scrum" + taskModif.Id.ToString(), contenidoHttpEnvio);

                ok = response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return ok;
        }
        public static async Task<bool> DelTask(int id)
        {
            bool ok = false;
            try
            {
                HttpResponseMessage response = await conexionHttp.DeleteAsync(urlWeb + "/api/Scrum/" + id.ToString());

                ok = response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return ok;
        }
    }
}
