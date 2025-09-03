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

            var response = datas.Select(d => new ResponseShortDataComemorativa
            {
                Id = d.Id,
                Name = d.Name,
                Date = d.Date,
                Description = d.Descryption  
            }).ToList();

            return new ResponseDataComemorativa
            {
                Datas = response
            };
        }
    }
}
