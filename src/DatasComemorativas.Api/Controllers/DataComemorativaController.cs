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
            [FromBody] RequestDataComemorativaRegister request,
            [FromServices] IRegisterDataComemorativaUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseDataComemorativaGetAll), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllDataComemorativaUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response.Datas.Any())
                return Ok(response);

            return NoContent();

        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseDataComemorativaUpdate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateDataComemorativaUseCase useCase,
            [FromBody] RequestDataComemorativaUpdate request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteDataComemorativaUseCase useCase,
            [FromQuery] RequestDataComemorativaDelete request)
        {

            var response = await useCase.Execute(request);
            return Ok(response);
        }

    }
}
