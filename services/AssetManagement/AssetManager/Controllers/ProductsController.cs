using AssetManager.Application.Commands;
using AssetManager.Application.Queries;
using AssetManager.Application.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public Task<IEnumerable<GetProductsResponse>> Get()
                => _mediator.Send(new GetAllProductSquery());

        [HttpGet("{ProductId}")]
        public Task<GetProductsResponse> GetProductById([FromRoute] GetProductQuery query) 
                => _mediator.Send(query);

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

    }
}