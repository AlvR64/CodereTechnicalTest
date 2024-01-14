using CodereTest.Domain.Entities;

namespace CodereTest.Domain.Services
{
    public interface ITvMazeService
    {
        Task<ShowItem?> GetShowById(int id, CancellationToken cancellationToken);
    }
}
