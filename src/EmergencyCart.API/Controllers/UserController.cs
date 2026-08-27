using EmergencyCart.Application.AccountContext.UseCases.Users.Create;
using EmergencyCart.Application.AccountContext.UseCases.Users.Update;
using EmergencyCart.Application.SharedContext.Results;
using EmergencyCart.Application.SharedContext.Results.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(EmergencyCart.Application.AccountContext.UseCases.Users.Create.Response), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create
            ([FromServices] ISender sender, 
            [FromBody] EmergencyCart.Application.AccountContext.UseCases.Users.Create.Command request)
        {
            var result = await sender.Send(request);    

            if (result.IsFailure)
            {
                return result.Error.type switch
                {
                    ErrorType.Conflict => Conflict(ErrorResponse.From(result.Error)),

                    _ => BadRequest(ErrorResponse.From(result.Error))
                };
            }

            return Created("", result.Value.message);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put
            ([FromServices] ISender sender, 
            [FromBody] EmergencyCart.Application.AccountContext.UseCases.Users.Update.Command request, 
            [FromRoute] Guid id)
        {
            var result = await sender.Send(request with { id = id});

            return Ok(result.Value);
        }
    }
}
