using AutoMapper;
using MediatR;
using SurveyManagement.Application.DTOs.Question;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Queries.Question.GetAll
{
    public class GetQuestionsQueryHandler(IMapper mapper, IQuestionRepository questionRepository) : IRequestHandler<GetQuestionsQuery, IEnumerable<QuestionDto>>
    {
        public async Task<IEnumerable<QuestionDto>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questions = await questionRepository.GetAllAsync(x=> true);
            return mapper.Map<IEnumerable<QuestionDto>>(questions);
        }
    }
}
