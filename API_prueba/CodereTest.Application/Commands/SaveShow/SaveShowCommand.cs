using CodereTest.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTest.Application.Commands.SaveShow
{
    public record SaveShowCommand(int id) : IRequest<ShowItem>;
}
