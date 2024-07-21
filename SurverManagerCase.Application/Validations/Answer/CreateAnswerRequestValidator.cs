using FluentValidation;
using SurveyManagement.Application.Features.Commands.answerRepository.Create;

namespace SurveyManagement.Application.Validations.Answer
{
    public class CreateAnswerRequestValidator : AbstractValidator<CreateAnswerCommandRequest>
    {
        public CreateAnswerRequestValidator()
        {
            RuleFor(a => a.QuestionId)
                .GreaterThan(0).WithMessage("QuestionId must be greater than 0.");

            RuleFor(a => a.Text)
                .NotEmpty().WithMessage("Answer text cannot be empty.")
                .MaximumLength(200).WithMessage("Answer text cannot exceed 200 characters.");
        }
    }

}
