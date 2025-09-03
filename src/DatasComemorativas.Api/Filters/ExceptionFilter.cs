using DataComemorativa.Communication.Responses;
using DataComemorativa.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DataComemorativa.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        //Toda vez que uma exceção for lançada, o método OnException será chamado
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DataComemorativaException)
            {
                //Tratar exceções específicas do projeto
                HandleProjectException(context);
            }
            else
            {   //Tratar exceções desconhecidas
                ThrowUnknowError(context);
            }
        }

        //Tratar exceções específicas do projeto
        private void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            {
                var ex = (ErrorOnValidationException)context.Exception;

                var errorResponse = new ResponseError(ex.Errors);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                context.Result = new BadRequestObjectResult(errorResponse);
            }

            //Se for outro tipo de exceção personalizada, pode ser tratado aqui
            else
            {
                var errorResponse = new ResponseError(context.Exception.Message); //para retornar uma mensagem de erro personalizada para o usuário, caso ele envie dados inválidos em formato Json

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }

        //Tratar exceções desconhecidas
        private void ThrowUnknowError(ExceptionContext context)
        {
            var errorResponse = new ResponseError("erro desconhecido");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
