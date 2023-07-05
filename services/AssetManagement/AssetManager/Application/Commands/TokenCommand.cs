using MediatR;

namespace AssetManager.WebApi.Application.Commands
{
    using Responses;

    public class TokenCommand : IRequest<TokenCommandResponse>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
