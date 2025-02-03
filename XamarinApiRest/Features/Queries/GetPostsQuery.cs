using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XamarinApiRest.Interfaces;
using XamarinApiRest.Models;

namespace XamarinApiRest.Features.Queries
{
    public class GetPostsQuery : IRequest<IEnumerable<Post>> { }

    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, IEnumerable<Post>>
    {
        private readonly IApiService _apiService;

        public GetPostsQueryHandler(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<Post>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return await _apiService.GetPostsAsync();
        }
    }
}
