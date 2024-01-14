using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTest.Application.Commands.DeleteShow
{
    public record DeleteShowCommand(int id) : IRequest;
}
