using System;
using System.Threading.Tasks;
using Abstractions.Bus;
using Contract.Commands.Users;
using Contract.Requests.Users;
using Contract.Responses.Users;
using Microsoft.AspNetCore.Mvc;
using SI_Platform.Models.Users;

namespace SI_Platform.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IRequestBus _requestBus;

        public UsersController(ICommandBus commandBus, IRequestBus requestBus)
        {
            _commandBus = commandBus;
            _requestBus = requestBus;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserModel model)
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

            var command = new AddUserCommand(id, model.Type, model.FirstName, model.LastName, model.Password,
                model.City, model.Phone, model.Email);

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _requestBus.RequestAsync<UsersRequest, UsersDTO>(new UsersRequest());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _requestBus.RequestAsync<UserRequest, UserDTO>(new UserRequest(id));

            if (response == null)
            {
                return BadRequest($"User {id} not found");
            }

            return Ok(response);
        }
    }
}