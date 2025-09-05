namespace DataComemorativa.Communication.Responses;
public class ResponseDeleteDataComemorativa
{
    public int Id { get; set; }
    public string Message { get; set; }

    public ResponseDeleteDataComemorativa(int id, string message)
    {
        Id = id;
        Message = message;
    }
}
