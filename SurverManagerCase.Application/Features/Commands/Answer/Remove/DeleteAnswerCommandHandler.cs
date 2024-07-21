using MediatR;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Commands.Answer.Remove
{
    public class DeleteAnswerCommandHandler(IAnswerRepository answerRepository) : IRequestHandler<DeleteAnswerCommandRequest, DeleteAnswerCommandResponse>
    {
        public async Task<DeleteAnswerCommandResponse> Handle(DeleteAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var question = await answerRepository.GetByIdAsync(request.Id);

            if (question == null)
            {
                return new DeleteAnswerCommandResponse { Success = false };
            }

            answerRepository.Remove(question);

            return new DeleteAnswerCommandResponse { Success = true };
        }
    }
}
