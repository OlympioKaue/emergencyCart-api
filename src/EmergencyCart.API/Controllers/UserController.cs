using EmergencyCart.Application.AccountContext.UseCases.Users.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromServices] ISender sender, [FromBody] Command request)
        {
            var result = await sender.Send(request);
            if (result.IsFailure)
                return BadRequest(result.Error.Message);

            return Ok(result.Value.id);
        }
    }
}
