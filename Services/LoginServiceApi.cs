using ScrumMaui.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScrumMaui.Services
{
    public static class LoginServiceApi
    {
        public static List<TaskModel> TaskList { get; private set; }

        private static JsonSerializerOptions serializerOptions;

        private static HttpClient conexionHttp;

        private static string urlWeb = ("http://192.168.0.29:5000");


        static LoginServiceApi()
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



        public static async Task<string> LoginUsuario(string nombreUsuario, string password)
        {
            string token = "";
            try
            {
                UserModel usuarioNombrePass = new UserModel()
                {
                    UserName = nombreUsuario,
                    Password = password
                };

                string cadJsonTarea = JsonSerializer.Serialize(usuarioNombrePass, serializerOptions);
                StringContent contenidoHttpEnvio = new StringContent(cadJsonTarea, Encoding.UTF8, "application/json");

                HttpResponseMessage respuesta = await conexionHttp.PostAsync(urlWeb + "/api/Login", contenidoHttpEnvio);

                if (respuesta.IsSuccessStatusCode)
                {
                    token = await respuesta.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return token;
        }

        public static async Task<List<TaskModel>> GetListaTareas(string token)
        {
            TaskList = new List<TaskModel>();

            try
            {
                conexionHttp.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await conexionHttp.GetAsync(urlWeb + "/api/Scrum");
                if (response.IsSuccessStatusCode)
                {
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
                Debug.Write(ex.Message);
                TaskList = null;
            }

            return TaskList;
        }
    }
}
