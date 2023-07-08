using AssetManager.Application.Domain;
using System.Security.Claims;

namespace AssetManager.WebApi.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUser User { get; }

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;

        var id = _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(q => q.Type == ClaimTypes.Sid)
            .Value;

        var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

        User = new CurrentUser(id, userName);
    }

    public bool IsInRole(string roleName) =>
        _httpContextAccessor.HttpContext!.User.IsInRole(roleName);
}
