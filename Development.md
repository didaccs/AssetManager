# Useful Commands

## Add new Migration
```bash
cd AssetManager\services\AssetManagement\AssetManager.Application

dotnet ef migrations add AddedBaseEntity -o Infrastructure/Migrations --startup-project ..\AssetManager\AssetManager.WebApi.csproj 
```

## Apply Migrations to DDBB
```bash
$env:DOTNET_ENVIRONMENT = 'Local' 

cd AssetManager\services\AssetManagement\AssetManager.Application

dotnet ef database update --startup-project ..\AssetManager\AssetManager.WebApi.csproj
```