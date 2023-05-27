# Configure the Azure provider
terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0.2"
    }
  }
  required_version = ">= 1.1.0"
}
provider "azurerm" {
  features {}
}

# Create the resource group
resource "azurerm_resource_group" "rg" {
  name     = "rg-assetmanagement-dev-northeu-001"
  location = "North Europe"
  tags     = {
    environment  = "development",
    project = "assetmanagement"
  } 
}