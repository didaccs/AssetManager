using MediatR;
using Microsoft.AspNetCore.Mvc;
using AssetManager.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using AssetManager.Application.Features.Auth.Commands;

namespace AssetManager.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<TokenCommandResponse> Token([FromBody] TokenCommand command) =>
            _mediator.Send(command);

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me([FromServices] ICurrentUserService currentUser)
        {
            return Ok(new
            {
                currentUser.User,
                IsAdmin = currentUser.IsInRole("Admin")
            });
        }
    }
}
