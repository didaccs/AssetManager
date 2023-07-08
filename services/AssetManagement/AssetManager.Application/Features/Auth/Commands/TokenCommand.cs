using MediatR;

namespace AssetManager.Application.Features.Auth.Commands;

public class TokenCommand : IRequest<TokenCommandResponse>
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}
