using DataComemorativa.Application.UseCases.DataComemorativa.GetAll;
using DataComemorativa.Application.UseCases.DataComemorativa.Register;
using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataComemorativa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataComemorativaController : ControllerBase
    {
        [HttpPost("data/inserir")]
        [ProducesResponseType(typeof(ResponseRegisterDataComemorativa), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromBody] RequestRegisterDataComemorativa request,
            [FromServices] IRegisterDataComemorativaUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseDataComemorativa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllDataComemorativaUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response.Datas.Count != 0)
                return Ok(response);

            return NoContent();

        }
    }
}
