using AutoMapper;
using MediatR;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Commands.Question.Create
{
    public class CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper) : IRequestHandler<CreateQuestionCommandRequest, CreateQuestionCommandResponse>
    {
        public async Task<CreateQuestionCommandResponse> Handle(CreateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var question = mapper.Map<SurveyManagement.Domain.Entities.Question>(request);
            await questionRepository.AddAsync(question);
            return mapper.Map<CreateQuestionCommandResponse>(question);
        }
    }
}