using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XamarinApiRest.Interfaces;
using XamarinApiRest.Models;

namespace XamarinApiRest.Features.Commands
{
    public class AddPostCommand : IRequest<bool>
    {
        public Post Post { get; set; }
        public AddPostCommand(Post post) => Post = post;
    }

    public class AddPostCommandHandler : IRequestHandler<AddPostCommand, bool>
    {
        private readonly IApiService _apiService;

        public AddPostCommandHandler(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<bool> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            return await _apiService.AddPostAsync(request.Post);
        }
    }
}
