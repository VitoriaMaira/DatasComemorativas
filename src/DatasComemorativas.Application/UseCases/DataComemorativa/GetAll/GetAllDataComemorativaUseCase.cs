using DataComemorativa.Communication.Responses;
using DataComemorativa.Domain.Repositories.DataComemorativa;

namespace DataComemorativa.Application.UseCases.DataComemorativa.GetAll
{
    public class GetAllDataComemorativaUseCase : IGetAllDataComemorativaUseCase

    {
        private readonly IDataComemorativaRepository _repository;


        public GetAllDataComemorativaUseCase(IDataComemorativaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDataComemorativa> Execute()
        {
            var datas = await _repository.GetAllAsync();

            var listaDataComemorativa = datas.Select(
                d => new ResponseShortDataComemorativa(d.Id, d.Name, d.Date, d.Description)).ToList();

            var response = new ResponseDataComemorativa(listaDataComemorativa);

            return response;
        }
    }
}
