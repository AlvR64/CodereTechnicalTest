using CodereTest.Domain.Entities;
using MediatR;

namespace CodereTest.Application.Queries.GetAllShows
{
    public record GetAllShowsQuery() : IRequest<List<ShowItem>>;
}
