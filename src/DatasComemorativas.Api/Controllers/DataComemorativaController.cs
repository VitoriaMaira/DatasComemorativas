using DataComemorativa.Application.UseCases.DataComemorativa.Delete;
using DataComemorativa.Application.UseCases.DataComemorativa.GetAll;
using DataComemorativa.Application.UseCases.DataComemorativa.Register;
using DataComemorativa.Application.UseCases.DataComemorativa.Update;
using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;
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

            return new NoContent();

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateDataComemorativaUseCase useCase,
            [FromRoute] int id,
            [FromBody] RequestRegisterDataComemorativa request)
        {
            await useCase.Execute(id, request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteDataComemorativaUseCase useCase,
            [FromRoute] int id)
        {
            await useCase.Execute(id);
            return NoContent();
        }

    }
}
