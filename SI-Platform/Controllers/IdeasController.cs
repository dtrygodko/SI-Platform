using System;
using System.Threading.Tasks;
using Abstractions.Bus;
using Contract.Commands.Ideas;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;
using Microsoft.AspNetCore.Mvc;
using SI_Platform.Models.Ideas;

namespace SI_Platform.Controllers
{
    [Route("api/ideas")]
    public class IdeasController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IRequestBus _requestBus;

        public IdeasController(ICommandBus commandBus, IRequestBus requestBus)
        {
            _commandBus = commandBus;
            _requestBus = requestBus;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddIdeaModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = Guid.NewGuid();

            var command = new AddIdeaCommand(id, model.Title, model.Description, model.AuthorId, model.StartFundingDate,
                model.StopFundingDate);

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetIdeasForAuthor(Guid authorId)
        {
            var request = new GetIdeasForAuthorRequest(authorId);

            var response = await _requestBus.RequestAsync<GetIdeasForAuthorRequest, IdeasDTO>(request);

            return Ok(response);
        }
    }
}