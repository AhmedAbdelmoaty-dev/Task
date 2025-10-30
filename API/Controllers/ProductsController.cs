using Application.Commands.Products.CreateProduct;
using Application.Commands.Products.Delete;
using Application.Commands.Products.Update;
using Application.DTOS;
using Application.Queries.Products.GetAll;
using Application.Queries.Products.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult>> GetAll([FromQuery] GetAllProductsQuery query)
        {
            if (!Request.Headers.TryGetValue("x-auth-token", out var token) || token != "mytoken")
            {
                return Unauthorized();
            }
            var result= await  _mediator.Send(query);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            if (!Request.Headers.TryGetValue("x-auth-token",out var token)|| token!="mytoken"){
                return Unauthorized();
            }
            var result=  await _mediator.Send(new GetProductByIdQuery(id));
           
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            if (!Request.Headers.TryGetValue("x-auth-token", out var token) || token != "mytoken")
            {
                return Unauthorized();
            }
            var id= await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id },command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateProductCommand command)
        {
            if (!Request.Headers.TryGetValue("x-auth-token", out var token) || token != "mytoken")
            {
                return Unauthorized();
            }
            command.Id = id;
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!Request.Headers.TryGetValue("x-auth-token", out var token) || token != "mytoken")
            {
                return Unauthorized();
            }
            await _mediator.Send(new DeleteProductCommand(id));

            return NoContent();
        }

       


    }
}
