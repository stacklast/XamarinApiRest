using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XamarinApiRest.Interfaces;
using XamarinApiRest.Models;

namespace XamarinApiRest.Features.Commands
{
    public class UpdatePostCommand : IRequest<bool>
    {
        public Post Post { get; set; }
        public UpdatePostCommand(Post post) => Post = post;
    }

    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, bool>
    {
        private readonly IApiService _apiService;

        public UpdatePostCommandHandler(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            return await _apiService.UpdatePostAsync(request.Post);
        }
    }
}
