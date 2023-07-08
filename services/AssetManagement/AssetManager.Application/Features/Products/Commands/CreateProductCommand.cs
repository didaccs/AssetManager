using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Application.Features.Products.Commands;

public class CreateProductCommand : IRequest
{
    [Required]
    public string Category { get; set; }
    [Required]
    public string Name { get; set; }
}
