using AutoMapper;
using SurveyManagement.Application.DTOs.Answer;
using SurveyManagement.Application.DTOs.Question;
using SurveyManagement.Application.DTOs.Survey;
using SurveyManagement.Application.Features.Commands.answerRepository.Create;
using SurveyManagement.Application.Features.Commands.Survey.Create;
using SurveyManagement.Application.Features.Commands.Survey.Remove;
using SurveyManagement.Application.Features.Commands.Survey.Update;
using SurveyManagement.Application.Messaging.DTOs;
using SurveyManagement.Domain.Entities;

namespace SurveyManagement.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Survey, SurveyDto>().ReverseMap();
            // CreateQuestionCommandRequest'ten Question'a eşleme
            CreateMap<CreateAnswerCommandRequest, Question>()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore());

            // Question'dan CreateQuestionCommandResponse'e eşleme
            CreateMap<Question, CreateAnswerCommandResponse>()
                .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src => src.CreatedByUser));

            // Question'dan QuestionDto'ya eşleme
            CreateMap<Question, QuestionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.SurveyId, opt => opt.MapFrom(src => src.SurveyId));

            // Request to Entity
            CreateMap<CreateSurveyCommandRequest, Survey>()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.Updated, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedByUser, opt => opt.Ignore());

            // Update Request to Entity
            CreateMap<UpdateSurveyCommandRequest, SurveyManagement.Domain.Entities.Survey>()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedByUser, opt => opt.Ignore());

            // Entity to Response
            CreateMap<SurveyManagement.Domain.Entities.Survey, CreateSurveyCommandResponse>()
                .ForMember(dest => dest.SurveyId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.IsSuccess, opt => opt.Ignore())
                .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore());

            // Entity to Response for Remove and Update
            CreateMap<SurveyManagement.Domain.Entities.Survey, RemoveSurveyCommandResponse>()
                .ForMember(dest => dest.IsSuccess, opt => opt.Ignore())
                .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore());

            CreateMap<SurveyManagement.Domain.Entities.Survey, UpdateSurveyCommandResponse>()
                .ForMember(dest => dest.IsSuccess, opt => opt.Ignore())
                .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore());

            CreateMap<Answer, AnswerDto>();
            CreateMap<CreateAnswerCommandRequest, Answer>().ReverseMap();
            CreateMap<Answer, CreateAnswerCommandResponse>().ReverseMap();

            CreateMap<SurveyCreatedMessage, CreateSurveyCommandRequest>();
            CreateMap<SurveyUpdatedMessage, UpdateSurveyCommandRequest>();

            
        }
    }
}