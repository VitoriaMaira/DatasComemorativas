using FluentValidation;

namespace DataComemorativa.Communication.Requests;
public record RequestDataComemorativaUpdate(int Id, string Name, DateTime Date, string? Description);

public class RequestDataComemorativaUpdateValidator : AbstractValidator<RequestDataComemorativaUpdate>
{
    public RequestDataComemorativaUpdateValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("O Id deve ser maior que zero.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome da data comemorativa é obrigatório.")
            .MaximumLength(100).WithMessage("O nome da data comemorativa não pode exceder 100 caracteres.");
        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("A data é obrigatória.")
            .Must(date => date > DateTime.MinValue).WithMessage("A data deve ser uma data válida.");
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("A descrição não pode exceder 500 caracteres.");
    }
}
