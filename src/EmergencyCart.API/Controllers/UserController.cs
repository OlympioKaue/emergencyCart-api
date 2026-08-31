using EmergencyCart.Application.AccountContext.UseCases.Users.Delete;
using EmergencyCart.Application.AccountContext.UseCases.Users.Read;
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

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutById
            ([FromServices] ISender sender,
            [FromBody] EmergencyCart.Application.AccountContext.UseCases.Users.Update.Command request,
            [FromRoute] Guid id)
        {
            var result = await sender.Send(request with { id = id });

            if (result.IsFailure)
            {
                return result.Error.type switch
                {
                    ErrorType.NotFound => NotFound(ErrorResponse.From(result.Error)),

                    _ => BadRequest(ErrorResponse.From(result.Error))
                };
            }

            return NoContent();
        }

        [ProducesResponseType(typeof(EmergencyCart.Application.AccountContext.UseCases.Users.Read.Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromServices] ISender sender, [FromRoute] Guid id)
        {
            var result = await sender.Send(new Query(id));

            if (result.IsFailure)
            {
                return NotFound(ErrorResponse.From(result.Error));
            }

            return Ok(result.Value);
        }


        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        //[HttpPut("password")]
        //public async Task<IActionResult> Put
        //  ([FromServices] ISender sender,
        //  [FromBody] EmergencyCart.Application.AccountContext.UseCases.Users.Update.Security.UpdatePassword.Command request)
        //{
        //    var result = await sender.Send(request);

        //    if (result.IsFailure)
        //    {
        //        return result.Error.type switch
        //        {
        //            ErrorType.NotFound => NotFound(ErrorResponse.From(result.Error)),

        //            _ => BadRequest(ErrorResponse.From(result.Error))
        //        };
        //    }

        //    return NoContent();
        //}

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteById
         ([FromServices] ISender sender, [FromRoute] Guid id)
        {
            var result = await sender.Send(new Command(id));

            if (result.IsFailure)
            {
                return result.Error.type switch
                {
                    ErrorType.NotFound => NotFound(ErrorResponse.From(result.Error)),

                    _ => BadRequest(ErrorResponse.From(result.Error))
                };
            }

            return NoContent();
        }

    }
}
