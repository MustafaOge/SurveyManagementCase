using MediatR;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Commands.Answer.Update
{
    public class UpdateAnswerCommandHandler(IAnswerRepository answerRepository) : IRequestHandler<UpdateAnswerCommandRequest, UpdateAnswerCommandResponse>
    {
        public async Task<UpdateAnswerCommandResponse> Handle(UpdateAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var answer = await answerRepository.GetByIdAsync(request.Id);

            if (answer == null)
            {
                return new UpdateAnswerCommandResponse { Success = false };
            }

            answer.Text = request.Text;

            answerRepository.Update(answer);

            return new UpdateAnswerCommandResponse { Success = true };
        }
    }
}
