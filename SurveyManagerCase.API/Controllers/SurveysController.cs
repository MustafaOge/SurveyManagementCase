using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurveyManagement.Application.Features.Commands.Survey.Create;
using SurveyManagement.Application.Features.Commands.Survey.Remove;
using SurveyManagement.Application.Features.Commands.Survey.Update;
using SurveyManagement.Application.Features.Queries.Survey.GetAll;
using SurveyManagement.Application.Features.Queries.Survey.GetById;
using SurveyManagement.Application.Messaging.Publisher;

namespace SurveyManagement.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SurveysController(IMediator _mediator, SurveyPublisher surveyPublisher) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSurveyCommandRequest request)
    {
        try
        {
            // Mesajı RabbitMQ'ya gönder
            await surveyPublisher.SendSurveyCreatedMessage(request.Title, request.Description, DateTime.Now);
            return Ok(new { message = "Survey created and message sent to RabbitMQ." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while creating the survey." });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSurveyCommandRequest request)
    {
        if (id != request.SurveyId)
        {
            return BadRequest(new { message = "Survey ID mismatch." });
        }

        try
        {
            // Mesajı RabbitMQ'ya gönder
            await surveyPublisher.SendSurveyUpdatedMessage(request.SurveyId, request.Title, request.Description, DateTime.Now);

            return Ok(new { message = "Survey updated and message sent to RabbitMQ." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while updating the survey." });
        }
    }
    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] CreateSurveyCommandRequest request)
    //{
    //    var response = await _mediator.Send(request);

    //    if (response == null)
    //    {
    //        return BadRequest(new { message = "An error occurred while creating the survey." });
    //    }

    //    return Ok(response);
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update(int id, [FromBody] UpdateSurveyCommandRequest request)
    //{
    //    if (id != request.SurveyId)
    //    {
    //        return BadRequest(new { message = "Survey ID mismatch." });
    //    }

    //    var response = await _mediator.Send(request);

    //    if (!response.IsSuccess)
    //    {
    //        return NotFound(new { message = response.ErrorMessage });
    //    }

    //    return Ok(response);
    //}

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var request = new RemoveSurveyCommandRequest { SurveyId = id };
        var response = await _mediator.Send(request);

        if (!response.IsSuccess)
        {
            return NotFound(new { message = response.ErrorMessage });
        }

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetSurveysQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetSurveyByIdQuery(id));
        return result != null ? Ok(result) : NotFound();
    }
}
