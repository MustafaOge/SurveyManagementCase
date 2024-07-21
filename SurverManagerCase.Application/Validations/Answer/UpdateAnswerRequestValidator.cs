using FluentValidation;
using SurveyManagement.Application.Features.Commands.Answer.Update;

namespace SurveyManagement.Application.Validations.Answer
{
    public class UpdateAnswerRequestValidator : AbstractValidator<UpdateAnswerCommandRequest>
    {
        public UpdateAnswerRequestValidator()
        {
            RuleFor(a => a.Id)
                .GreaterThan(0).WithMessage("QuestionId must be greater than 0.");

            RuleFor(a => a.Text)
                .NotEmpty().WithMessage("Answer text cannot be empty.")
                .MaximumLength(200).WithMessage("Answer text cannot exceed 200 characters.");
        }
    }

}
