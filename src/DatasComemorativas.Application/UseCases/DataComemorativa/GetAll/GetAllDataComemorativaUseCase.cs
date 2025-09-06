using DataComemorativa.Communication.Responses;
using DataComemorativa.Domain.Repositories.DataComemorativa;

namespace DataComemorativa.Application.UseCases.DataComemorativa.GetAll
{
    public class GetAllDataComemorativaUseCase : IGetAllDataComemorativaUseCase

    {
        private readonly IDataComemorativaRepository _dataComemorativaRepository;


        public GetAllDataComemorativaUseCase(IDataComemorativaRepository dataComemorativaRepository)
        {
            _dataComemorativaRepository = dataComemorativaRepository;
        }

        public async Task<ResponseDataComemorativaGetAll> Execute()
        {
            var datas = await _dataComemorativaRepository.GetAllAsync();

            var listaDataComemorativa = datas.Select(
                d => new ResponseShortDataComemorativa(d.Id, d.Name, d.Date, d.Description)).ToList();

            var response = new ResponseDataComemorativaGetAll(listaDataComemorativa);

            return response;
        }
    }
}
