using AssetManager.WebApi.Domain;

namespace AssetManager.WebApi.Services;

public interface ICurrentUserService
{
    CurrentUser User { get; }

    bool IsInRole(string roleName);
}
