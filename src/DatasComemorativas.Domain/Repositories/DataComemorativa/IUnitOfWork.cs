namespace DataComemorativa.Domain.Repositories.DataComemorativa
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
