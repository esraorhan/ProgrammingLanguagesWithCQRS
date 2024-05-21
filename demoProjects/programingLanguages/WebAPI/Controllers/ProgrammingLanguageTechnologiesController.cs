using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageTechnologyQuery getListQuery = new GetListProgrammingLanguageTechnologyQuery { PageRequest = pageRequest };
            ProgrammingLanguageTechnologyListModel result = await Mediator.Send(getListQuery);
            return Ok(result);
        }
    }
}
