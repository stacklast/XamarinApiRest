using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XamarinApiRest.Interfaces;

namespace XamarinApiRest.Features.Commands
{
    public class DeletePostCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DeletePostCommand(int id) => Id = id;
    }

    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, bool>
    {
        private readonly IApiService _apiService;

        public DeletePostCommandHandler(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            return await _apiService.DeletePostAsync(request.Id);
        }
    }
}
