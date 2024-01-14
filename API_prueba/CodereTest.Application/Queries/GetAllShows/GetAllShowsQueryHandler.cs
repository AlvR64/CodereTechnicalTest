using CodereTest.Application.Queries.GetAllShows;
using CodereTest.Domain.Entities;
using CodereTest.Domain.Repositories;
using MediatR;

namespace CodereTest.Application.Queries.GetShow
{
    public class GetAllShowsQueryHandler : IRequestHandler<GetAllShowsQuery, List<ShowItem>>
    {
        private readonly IShowItemRepository _repository;

        public GetAllShowsQueryHandler(IShowItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ShowItem>> Handle(GetAllShowsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }
    }
}
