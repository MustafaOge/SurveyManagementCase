using AutoMapper;
using MediatR;
using SurveyManagement.Application.DTOs.Answer;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Queries.Answer.GetAll
{
    public class GetAnswersQueryHandler(IMapper mapper, IAnswerRepository answerRepository) : IRequestHandler<GetAnswersQuery, IEnumerable<AnswerDto>>
    {

        public async Task<IEnumerable<AnswerDto>> Handle(GetAnswersQuery request, CancellationToken cancellationToken)
        {
            var answer = await answerRepository.GetAllAsync(x=> true);
            return mapper.Map<IEnumerable<AnswerDto>>(answer);
        }
    }
}
