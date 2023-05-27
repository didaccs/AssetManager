# Relational Database
resource "azurerm_mssql_server" "db-sql-server" {
  name                      = "sql-assetmanagement-development-northeu-001"
  location                  = azurerm_resource_group.rg.location
  resource_group_name       = azurerm_resource_group.rg.name
  tags                      = azurerm_resource_group.rg.tags
  version                   = "12.0"
  minimum_tls_version       = "1.2"
  administrator_login                   = var.db_username
  administrator_login_password          = var.db_password
  public_network_access_enabled         = true
  outbound_network_restriction_enabled  = false
}

resource "azurerm_mssql_database" "db-sql-data" {
  name           = "db-assetmanagement-storage"
  server_id      = azurerm_mssql_server.db-sql-server.id
  license_type   = "LicenseIncluded"
  sku_name       = "Free"
  zone_redundant = false
  tags           = azurerm_resource_group.rg.tags
}