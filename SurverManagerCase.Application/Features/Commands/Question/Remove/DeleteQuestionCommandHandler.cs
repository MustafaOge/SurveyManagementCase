using MediatR;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Commands.Question.Remove
{
    public class DeleteAnswerCommandHandler(IQuestionRepository questionRepository) : IRequestHandler<DeleteAnswerCommandRequest, DeleteAnswerCommandResponse>
    {
  


        public async Task<DeleteAnswerCommandResponse> Handle(DeleteAnswerCommandRequest request, CancellationToken cancellationToken)
        {
            var question = await questionRepository.GetByIdAsync(request.Id);

            if (question == null)
            {
                return new DeleteAnswerCommandResponse { Success = false };
            }

             questionRepository.Remove(question);

            return new DeleteAnswerCommandResponse { Success = true };
        }
    }
}
