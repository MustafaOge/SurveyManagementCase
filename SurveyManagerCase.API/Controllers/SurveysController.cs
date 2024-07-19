using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurveyManagement.Application.Features.Commands.Survey.Create;
using SurveyManagement.Application.Features.Commands.Survey.Remove;
using SurveyManagement.Application.Features.Commands.Survey.Update;
using SurveyManagement.Application.Features.Queries.Survey.GetAll;
using SurveyManagement.Application.Features.Queries.Survey.GetById;

namespace SurveyManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SurveysController(IMediator _mediator) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSurveyCommandRequest request)
    {
        var response = await _mediator.Send(request);

        if (response == null)
        {
            return BadRequest(new { message = "An error occurred while creating the survey." });
        }

        return Ok(response);
    }

    // Update
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSurveyCommandRequest request)
    {
        if (id != request.SurveyId)
        {
            return BadRequest(new { message = "Survey ID mismatch." });
        }

        var response = await _mediator.Send(request);

        if (!response.IsSuccess)
        {
            return NotFound(new { message = response.ErrorMessage });
        }

        return Ok(response);
    }

    // Remove
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
    public async Task<IActionResult> GetSurveys()
    {
        var result = await _mediator.Send(new GetSurveysQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSurveyById(int id)
    {
        var result = await _mediator.Send(new GetSurveyByIdQuery(id));
        return result != null ? Ok(result) : NotFound();
    }



}
