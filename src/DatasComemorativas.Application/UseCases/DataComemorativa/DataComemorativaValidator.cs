using DataComemorativa.Communication.Requests;
using FluentValidation;

namespace DataComemorativa.Application.UseCases.DataComemorativa
{
    // Validador para o request de registro de data comemorativa
    public class DataComemorativaValidator : AbstractValidator<RequestDataComemorativa>
    {
        public DataComemorativaValidator()
        {
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
}
