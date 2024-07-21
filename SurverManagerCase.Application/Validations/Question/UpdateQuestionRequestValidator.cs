using FluentValidation;
using SurveyManagement.Application.Features.Commands.Question.Update;

namespace SurveyManagement.Application.Validations.Question
{
    public class UpdateQuestionRequestValidator : AbstractValidator<UpdateQuestionCommandRequest>
    {
        public UpdateQuestionRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("QuestionId must be greater than 0.");

            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Question text cannot be empty.")
                .MaximumLength(500).WithMessage("Question text cannot exceed 500 characters.");
        }
    }
}
