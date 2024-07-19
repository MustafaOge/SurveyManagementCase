using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurveyManagement.Application.Features.Commands.Answer.Remove;
using SurveyManagement.Application.Features.Commands.Answer.Update;
using SurveyManagement.Application.Features.Commands.answerRepository.Create;
using SurveyManagement.Application.Features.Queries.Answer.GetAll;
using SurveyManagement.Application.Features.Queries.Answer.GetById;

namespace SurveyManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController(IMediator mediator) : ControllerBase
    {
        // Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnswerCommandRequest request)
        {
            var response = await mediator.Send(request);

            if (response == null)
            {
                return BadRequest(new { message = "An error occurred while creating the question." });
            }

            return CreatedAtAction(nameof(GetQuestionById), new { id = response.QuestionId }, response);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAnswerCommandRequest request)
        {


            var response = await mediator.Send(request);

            if (response == null)
            {
                return NotFound(new { message = "Question not found or update failed." });
            }

            return Ok(response);
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var request = new DeleteAnswerCommandRequest { Id = id };
            var response = await mediator.Send(request);

            if (!response.Success)
            {
                return NotFound(new { message = "Question not found or delete failed." });
            }

            return NoContent();
        }

        // Get all questions
        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var result = await mediator.Send(new GetAnswersQuery());
            return Ok(result);
        }

        // Get question by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var result = await mediator.Send(new GetAnswerByIdQuery(id));
            return result != null ? Ok(result) : NotFound();
        }
    }
}
