using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinApiRest.Configurations;
using XamarinApiRest.Interfaces;
using XamarinApiRest.Models;

namespace XamarinApiRest.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiConfig.JsonPlaceholderEndpoint)
            };
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("posts");
                return JsonConvert.DeserializeObject<IEnumerable<Post>>(response);
            }
            catch (HttpRequestException ex)
            {
                // Manejo de errores de red
                Console.WriteLine($"Error de red: {ex.Message}");
                throw new Exception("No se pudo obtener la lista de posts.");
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener la lista de posts.");
            }
        }

        public async Task<Post> GetPostAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"posts/{id}");
                return JsonConvert.DeserializeObject<Post>(response);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de red: {ex.Message}");
                throw new Exception("No se pudo obtener el post.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener el post.");
            }
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("users");
                return JsonConvert.DeserializeObject<IEnumerable<User>>(response);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de red: {ex.Message}");
                throw new Exception("No se pudo obtener la lista de usuarios.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener la lista de usuarios.");
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"users/{id}");
                return JsonConvert.DeserializeObject<User>(response);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de red: {ex.Message}");
                throw new Exception("No se pudo obtener el usuario.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener el usuario.");
            }
        }

        public async Task<bool> AddPostAsync(Post post)
        {
            try
            {
                var json = JsonConvert.SerializeObject(post);
                var response = await _httpClient.PostAsync("posts", new StringContent(json, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de red: {ex.Message}");
                throw new Exception("No se pudo agregar el post.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Ocurrió un error al agregar el post.");
            }
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            try
            {
                var json = JsonConvert.SerializeObject(post);
                var response = await _httpClient.PutAsync($"posts/{post.Id}", new StringContent(json, Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de red: {ex.Message}");
                throw new Exception("No se pudo actualizar el post.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Ocurrió un error al actualizar el post.");
            }
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"posts/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de red: {ex.Message}");
                throw new Exception("No se pudo eliminar el post.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Ocurrió un error al eliminar el post.");
            }
        }
    }
}
