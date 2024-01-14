using CodereTest.Domain.Entities;
using CodereTest.Domain.Repositories;
using CodereTest.Domain.Services;
using ISF.FAF_RF.Domain.Common;
using MediatR;

namespace CodereTest.Application.Queries.GetShow
{
    public class GetShowQueryHandler : IRequestHandler<GetShowQuery, ShowItem>
    {
        private readonly ITvMazeService _service;

        public GetShowQueryHandler(ITvMazeService service)
        {
            _service = service;
        }

        public async Task<ShowItem> Handle(GetShowQuery request, CancellationToken cancellationToken)
        {
            var showItemFound = await _service.GetShowById(request.id, cancellationToken);
            if(showItemFound == null) throw new AppException(CustomError.IdError);

            return showItemFound;
        }
    }
}
