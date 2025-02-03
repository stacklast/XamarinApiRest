using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XamarinApiRest.Interfaces;
using XamarinApiRest.Models;

namespace XamarinApiRest.Features.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>> { }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly IApiService _apiService;

        public GetUsersQueryHandler(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _apiService.GetUsersAsync();
        }
    }
}
