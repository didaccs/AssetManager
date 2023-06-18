﻿using AssetManager.Application.Queries.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Application.Queries;

public class GetProductQuery : IRequest<GetProductsResponse>
{
    [Required]
    public string ProductId { get; set; }

}
