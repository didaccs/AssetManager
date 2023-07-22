using AssetManager.Application.Domain;

namespace AssetManager.Application.Services;

public interface ICurrentUserService
{
    CurrentUser User { get; }

    bool IsInRole(string roleName);
}
