using CQRSMediatR.DataAccess.CQRS.Commands.Request;
using CQRSMediatR.DataAccess.CQRS.Commands.Response;
using CQRSMediatR.DataAccess.CQRS.Queries.Request;
using CQRSMediatR.DataAccess.CQRS.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest requestModel)
        {
            List<GetAllProductQueryResponse> result = await _mediator.Send(requestModel);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProductQueryRequest requestModel)
        {
            GetByIdProductQueryResponse result = await _mediator.Send(requestModel);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommandRequest requestModel)
        {
            DeleteProductCommandResponse result = await _mediator.Send(requestModel);
            return Ok(result);
        }
    }
}
