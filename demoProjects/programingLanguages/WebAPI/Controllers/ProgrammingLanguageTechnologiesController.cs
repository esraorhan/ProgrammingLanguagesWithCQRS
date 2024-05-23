using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologyByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageTechnologyQuery getByIdProgrammingLanguageTechnology)
        {
            ProgrammingLanguageTechnologyGetByIdDto PLGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageTechnology);
            return Ok(PLGetByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageTechnologyCommand createCommand)
        {
            CreatedProgrammingLanguageTechnologyDto result = await Mediator.Send(createCommand);
            return Created("", result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageTechnologyCommand updateProgrammingLanguageTechnology)
        {
            UpdatedProgrammingLanguageTechnologyDto updatedProgrammingLanguageTechnologyDto = await Mediator.Send(updateProgrammingLanguageTechnology);

            return Ok(updatedProgrammingLanguageTechnologyDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageTechnologyCommand deleteProgramming)
        {
            DeletedProgrammingLanguageTechnologyDto deletedProgrammingLanguageTechnologyDto = await Mediator.Send(deleteProgramming);

            return Ok(deletedProgrammingLanguageTechnologyDto);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListProgrammingLanguageTechnologyByDynamicQuery getListModelByDynamicQuery = new GetListProgrammingLanguageTechnologyByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            ProgrammingLanguageTechnologyListModel result = await Mediator.Send(getListModelByDynamicQuery);
            return Ok(result);
        }
    }
}
