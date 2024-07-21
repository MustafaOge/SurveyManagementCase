using MediatR;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Commands.Question.Update
{
    public class UpdateQuestionCommandHandler(IQuestionRepository questionRepository) : IRequestHandler<UpdateQuestionCommandRequest, UpdateQuestionCommandResponse>
    {
        public async Task<UpdateQuestionCommandResponse> Handle(UpdateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var question = await questionRepository.GetByIdAsync(request.Id);

            if (question == null)
            {
                return new UpdateQuestionCommandResponse { Success = false };
            }

            question.Text = request.Text;

             questionRepository.Update(question);

            return new UpdateQuestionCommandResponse { Success = true };
        }
    }
}
