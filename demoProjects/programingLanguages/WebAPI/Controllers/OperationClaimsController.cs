using Application.Features.OperationClaims.Commands;
using Application.Features.OperationClaims.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaim)
        {
            CreatedOperationClaimDto result = await Mediator.Send(createOperationClaim);
            return Created("", result);
        }
    }
}
