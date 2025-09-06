using FluentValidation;

namespace DataComemorativa.Communication.Requests;
public record RequestDataComemorativaDelete(int Id);

public class RequestDataComemorativaDeleteValidator : AbstractValidator<RequestDataComemorativaDelete>
{
    public RequestDataComemorativaDeleteValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("O Id deve ser maior que zero.");
    }
}
