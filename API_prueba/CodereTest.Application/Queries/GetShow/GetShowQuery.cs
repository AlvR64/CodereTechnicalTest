using CodereTest.Domain.Entities;
using MediatR;

namespace CodereTest.Application.Queries.GetShow
{
    public record GetShowQuery(int id) : IRequest<ShowItem>;
}
