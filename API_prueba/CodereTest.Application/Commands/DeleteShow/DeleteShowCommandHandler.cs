using CodereTest.Domain.Repositories;
using ISF.FAF_RF.Domain.Common;
using MediatR;

namespace CodereTest.Application.Commands.DeleteShow
{
    public class DeleteShowCommandHandler : IRequestHandler<DeleteShowCommand>
    {
        private readonly IShowItemRepository _repository;

        public DeleteShowCommandHandler(IShowItemRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteShowCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.id, cancellationToken);
        }
    }
}
