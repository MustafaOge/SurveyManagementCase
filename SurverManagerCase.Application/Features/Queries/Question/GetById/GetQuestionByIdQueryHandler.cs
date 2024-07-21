using AutoMapper;
using MediatR;
using SurveyManagement.Application.DTOs.Question;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Queries.Question.GetById
{
    public class GetQuestionByIdQueryHandler(IMapper mapper, IQuestionRepository questionRepository) : IRequestHandler<GetQuestionByIdQuery, QuestionDto>
    {
        public async Task<QuestionDto> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var question = await questionRepository.GetByIdAsync(request.Id);
            return mapper.Map<QuestionDto>(question);
        }
    }
}
