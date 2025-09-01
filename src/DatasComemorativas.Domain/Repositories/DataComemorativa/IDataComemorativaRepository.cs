using DataComemorativa.Domain.Entities;

namespace DataComemorativa.Domain.Repositories.DataComemorativa
{
    //Interface para o repositório de datas comemorativas
    public interface IDataComemorativaRepository
    {
        // Método para adicionar uma nova data comemorativa
        void Add(Data data);
    }
}
