using AssetManager.Application.Domain;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AssetManager.Application.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUser User { get; }

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;

        // Application initialization
        if (_httpContextAccessor is null || _httpContextAccessor.HttpContext is null)
        {
            User = new CurrentUser(Guid.Empty.ToString(), string.Empty, false);
            return;
        }

        // Valid HttpRequest but User not autenticated
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext!.User!.Identity!.IsAuthenticated == false)
        {
            User = new CurrentUser(Guid.Empty.ToString(), string.Empty, false);
            return;
        }

        var id = httpContext.User.Claims
            .FirstOrDefault(q => q.Type == ClaimTypes.Sid)!
            .Value;

        var userName = httpContext.User!.Identity!.Name ?? "Unknown";

        User = new CurrentUser(id, userName, true);
    }

    public bool IsInRole(string roleName) =>
        _httpContextAccessor.HttpContext!.User.IsInRole(roleName);
}
