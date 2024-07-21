using FluentValidation;
using SurveyManagement.Application.Features.Commands.Survey.Update;

namespace SurveyManagement.Application.Validations.Survey
{
    public class UpdateSurveyRequestValidator : AbstractValidator<UpdateSurveyCommandRequest>
    {
        public UpdateSurveyRequestValidator()
        {
            RuleFor(dto => dto.SurveyId)
                .GreaterThan(0).WithMessage("SurveyId must be greater than 0.");

            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage("Title is Required.")
                .MaximumLength(115).WithMessage("Title cannot exceed 115 characters.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is Required.")
                .MaximumLength(255).WithMessage("Description cannot exceed 255 characters.");
        }
    }
}
