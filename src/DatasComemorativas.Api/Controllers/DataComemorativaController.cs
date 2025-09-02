using DataComemorativa.Application.UseCases.DataComemorativa.Register;
using DataComemorativa.Communication.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataComemorativa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataComemorativaController : ControllerBase
    {
        [HttpPost("data/inserir")]
        public async Task<IActionResult> InserirDataComemorativa(
            [FromBody] RegisterDataComemorativaRequest request,
            [FromServices] IRegisterDataComemorativaUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Ok(response);
        }
    }
}
