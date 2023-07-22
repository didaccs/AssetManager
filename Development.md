# Useful Commands

## Add new Migration
```bash
cd AssetManager\services\AssetManagement\AssetManager.Application

dotnet ef migrations add AddedBaseEntity -o Infrastructure/Migrations --startup-project ..\AssetManager\AssetManager.WebApi.csproj 

dotnet ef database update --startup-project ..\AssetManager\AssetManager.WebApi.csproj
```