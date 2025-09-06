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
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterDataComemorativa), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromBody] RequestDataComemorativa request,
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

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseUpdateDataComemorativa), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateDataComemorativaUseCase useCase,
            [FromRoute] int id,
            [FromBody] RequestDataComemorativa request)
        {
            var response = await useCase.Execute(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteDataComemorativaUseCase useCase,
            [FromRoute] int id)
        {

            var response = await useCase.Execute(id);
            return Ok(response);
        }

    }
}
