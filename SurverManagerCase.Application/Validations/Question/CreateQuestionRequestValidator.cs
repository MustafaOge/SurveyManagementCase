using FluentValidation;
using SurveyManagement.Application.Features.Commands.Question.Create;

namespace SurveyManagement.Application.Validations.Question
{
    public class CreateQuestionRequestValidator : AbstractValidator<CreateQuestionCommandRequest>
    {
        public CreateQuestionRequestValidator()
        {
            RuleFor(q => q.SurveyId)
                .GreaterThan(0).WithMessage("SurveyId must be greater than 0.");

            RuleFor(q => q.Text)
                .NotEmpty().WithMessage("Question text cannot be empty.")
                .MaximumLength(500).WithMessage("Question text cannot exceed 500 characters.");
        }
    }
}
