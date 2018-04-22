using System;
using System.Threading.Tasks;
using Abstractions.Bus;
using Contract.Commands.Ideas;
using Contract.Requests.Ideas;
using Contract.Requests.Users;
using Contract.Responses.Ideas;
using Contract.Responses.Users;
using Microsoft.AspNetCore.Mvc;
using SI_Platform.Models.Ideas;

namespace SI_Platform.Controllers
{
    [Route("api/users/{userId}/ideas")]
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
        public async Task<IActionResult> Add(Guid userId, [FromBody] AddIdeaModel model)
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

            var command = new AddIdeaCommand(id, model.Title, model.Description, userId, model.StartFundingDate,
                model.StopFundingDate);

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetIdeasForAuthor(Guid userId)
        {
            var request = new GetIdeasForAuthorRequest(userId);

            var response = await _requestBus.RequestAsync<GetIdeasForAuthorRequest, IdeasDTO>(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdeaForAuthor(Guid userId, Guid id)
        {
            var user = _requestBus.RequestAsync<UserRequest, UserDTO>(new UserRequest(userId));

            if (user == null)
            {
                return BadRequest($"User {userId} not found");
            }

            var request = new IdeaRequest(id);

            var response = await _requestBus.RequestAsync<IdeaRequest, IdeaDTO>(request);

            if (response == null)
            {
                return BadRequest($"Idea {id} not found");
            }

            return Ok(response);
        }
    }
}