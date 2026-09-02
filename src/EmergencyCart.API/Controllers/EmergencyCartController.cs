using EmergencyCart.Application.AccountContext.UseCases.EmergencyCarts.Create;
using EmergencyCart.Application.SharedContext.Results;
using EmergencyCart.Application.SharedContext.Results.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyCartController : ControllerBase
    {
        [ProducesResponseType(typeof(EmergencyCart.Application.AccountContext.UseCases.EmergencyCarts.Create.Response), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create
            ([FromServices] ISender sender,
            [FromBody] EmergencyCart.Application.AccountContext.UseCases.EmergencyCarts.Create.Command request)
        {
            var result = await sender.Send(request);
            if (result.IsFailure)
            {
                return result.Error.type switch
                {
                    ErrorType.NotFound => NotFound(ErrorResponse.From(result.Error)),

                    _ => BadRequest(ErrorResponse.From(result.Error))
                };
            }

            return Created("", result.Value.message);
        }
    }
}
