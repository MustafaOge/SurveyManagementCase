using AutoMapper;
using MediatR;
using SurveyManagement.Application.DTOs.Answer;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Queries.Answer.GetById
{
    public class GetAnswerByIdQueryHandler(IMapper mapper, IAnswerRepository answerRepository) : IRequestHandler<GetAnswerByIdQuery, AnswerDto>
    {

        public async Task<AnswerDto> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
        {
            var answer = await answerRepository.GetByIdAsync(request.Id);
            return mapper.Map<AnswerDto>(answer);
        }
    }
}
