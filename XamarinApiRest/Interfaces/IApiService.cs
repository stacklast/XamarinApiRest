using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinApiRest.Models;

namespace XamarinApiRest.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<bool> AddPostAsync(Post post);
        Task<bool> UpdatePostAsync(Post post);
        Task<bool> DeletePostAsync(int id);
    }
}
