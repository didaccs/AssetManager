Asset Manager
=======


# Architecture Overview
The backend of the Asset Management project is REST API developed using C#.

It follows the principles of CQRS (Command Query Responsibility Segregation) and DDD (Domain-Driven Design) to ensure a clean separation of concerns.

The code is structured using the Vertical Slice architecture pattern. This approach organizes the codebase based on features or vertical slices rather than layers. 

# Technologies Used
The following technologies and frameworks are utilized in the backend RestApi:

 - **C#**: The programming language used for the development of the application.
 - **ASP.NET Core**: The framework used for building the RestApi and handling HTTP requests.
 - **CQRS**: The architectural pattern used to separate the read and write operations.
 - **JWT (JSON Web Tokens)**: A secure method for transmitting authentication and authorization information.
 - **Fluent Validation**: A validation library used for defining and enforcing validation rules.
 - **Auto Mapper**: An utility to easy mapping domain objects to DTO.
 - **DDD (Domain-Driven Design)**: A design approach that focuses on modeling the business domain.


# Infrastructure
The infrastructure of the project is deployed on Azure and has the follow items:
 - Azure SQL Database

This infrastructure has been managed as IaC using Terraform.
