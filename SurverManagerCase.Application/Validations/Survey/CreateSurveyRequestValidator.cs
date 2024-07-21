using FluentValidation;
using SurveyManagement.Application.Features.Commands.Survey.Create;

namespace SurveyManagement.Application.Validations.Survey
{
    public class CreateSurveyRequestValidator : AbstractValidator<CreateSurveyCommandRequest>
    {
        public CreateSurveyRequestValidator()
        {
            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage("Title is Required").
                MaximumLength(115).WithMessage("Title cannot exceed 115 characters.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is Required").
                MaximumLength(255).WithMessage("Description cannot exceed 255 characters");
        }
    }
}
