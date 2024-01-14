using CodereTest.Domain.Entities;
using CodereTest.Domain.Repositories;
using CodereTest.Domain.Services;
using ISF.FAF_RF.Domain.Common;
using MediatR;

namespace CodereTest.Application.Commands.SaveShow
{
    public class SaveShowCommandHandler : IRequestHandler<SaveShowCommand, ShowItem>
    {
        private readonly IShowItemRepository _repository;
        private readonly ITvMazeService _service;

        public SaveShowCommandHandler(IShowItemRepository showItemRepository, ITvMazeService tvMazeService)
        {
            _repository = showItemRepository;
            _service = tvMazeService;
        }

        public async Task<ShowItem> Handle(SaveShowCommand request, CancellationToken cancellationToken)
        {
            var showItemAlreadySaved = await _repository.Exists(request.id, cancellationToken);
            if (showItemAlreadySaved) throw new AppException(CustomError.SaveError);

            var showItemResponse = await _service.GetShowById(request.id, cancellationToken);
            if (showItemResponse == null) throw new AppException(CustomError.IdError);

            return await _repository.Save(showItemResponse, cancellationToken);
        }
    }
}
