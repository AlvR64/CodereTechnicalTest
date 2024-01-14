using CodereTest.Application.Commands.DeleteShow;
using CodereTest.Application.Commands.SaveShow;
using CodereTest.Application.Queries.GetAllShows;
using CodereTest.Application.Queries.GetShow;
using CodereTest.Controllers;
using CodereTest.Domain.Entities;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CodereTest.Tests.UnitTests.API
{
    public class ShowsControllerTest
    {
        private readonly ShowsController _controller;
        private readonly Mock<ISender> _sender;
        private readonly CancellationToken _cancellationToken;

        public ShowsControllerTest()
        {
            _sender = new Mock<ISender>();
            _controller = new ShowsController(_sender.Object);
        }

        [Fact]
        public async void ShouldReturnShowById()
        {
            var showItem = new ShowItem { Id = 1, Name = "Under the Dome", Status = "Ended" };
            _sender
                .Setup(x => x.Send(new GetShowQuery(showItem.Id), _cancellationToken))
                .ReturnsAsync(showItem);

            var response = await _controller.GetShow(showItem.Id, _cancellationToken);

            response.Should().BeOfType<OkObjectResult>();
            var okResult = response as OkObjectResult;
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().NotBeNull();
            var showItemResponse = okResult.Value as ShowItem;
            showItemResponse!.Should().BeEquivalentTo(showItem);
        }

        [Fact]
        public async void ShouldReturnAllSavedShows()
        {
            var showItems = new List<ShowItem> { new ShowItem { Id = 1, Name = "Under the Dome", Status = "Ended" } };
            _sender
                .Setup(x => x.Send(new GetAllShowsQuery(), _cancellationToken))
                .ReturnsAsync(showItems);

            var response = await _controller.GetAllShows(_cancellationToken);

            response.Should().BeOfType<OkObjectResult>();
            var okResult = response as OkObjectResult;
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().NotBeNull();
            var showItemResponse = okResult.Value as List<ShowItem>;
            showItemResponse!.Should().BeEquivalentTo(showItems);
        }

        [Fact]
        public async void ShouldSaveShow()
        {
            var showItem = new ShowItem { Id = 1, Name = "Under the Dome", Status = "Ended" };
            _sender
                .Setup(x => x.Send(new SaveShowCommand(showItem.Id), _cancellationToken))
                .ReturnsAsync(showItem);

            var response = await _controller.SaveShow(showItem.Id, _cancellationToken);

            response.Should().BeOfType<CreatedResult>();
            var okResult = response as CreatedResult;
            okResult!.StatusCode.Should().Be(201);
            okResult.Value.Should().NotBeNull();
            var showItemResponse = okResult.Value as ShowItem;
            showItemResponse!.Should().BeEquivalentTo(showItem);
        }

        [Fact]
        public async void ShouldDeleteShowById()
        {
            var showItem = new ShowItem { Id = 1, Name = "Under the Dome", Status = "Ended" };
            _sender
                .Setup(x => x.Send(new DeleteShowCommand(showItem.Id), _cancellationToken));

            var response = await _controller.DeleteShow(showItem.Id, _cancellationToken);
             
            response.Should().BeOfType<OkObjectResult>();
            var okResult = response as OkObjectResult;
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().Be(true);
        }
    }
}
