using CodereTest.Application.Commands.DeleteShow;
using CodereTest.Application.Commands.SaveShow;
using CodereTest.Application.Queries.GetAllShows;
using CodereTest.Application.Queries.GetShow;
using CodereTest.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CodereTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowsController : ControllerBase
    {
        private readonly ISender _sender;

        public ShowsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("{id}")]
        [SwaggerOperation(Summary = "Saves a show from the external API to DB")]
        public async Task<IActionResult> SaveShow([Required] int id, CancellationToken cancellationToken)
        {
            var showItem = await _sender.Send(new SaveShowCommand(id), cancellationToken);
            return Created(nameof(SaveShow), showItem);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a show from DB")]
        public async Task<IActionResult> DeleteShow([Required] int id, CancellationToken cancellationToken)
        {
            await _sender.Send(new DeleteShowCommand(id), cancellationToken);
            return Ok(true);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a show from external API")]
        public async Task<IActionResult> GetShow([Required] int id, CancellationToken cancellationToken)
        {
            var showItemFound = await _sender.Send(new GetShowQuery(id), cancellationToken);
            return Ok(showItemFound);
        }

        [HttpGet("all")]
        [SwaggerOperation(Summary = "Get all shows from DB")]
        public async Task<IActionResult> GetAllShows(CancellationToken cancellationToken)
        {
            var showItemsFound = await _sender.Send(new GetAllShowsQuery(), cancellationToken);
            return Ok(showItemsFound);
        }
    }
}
