using Microsoft.AspNetCore.Mvc;
using SurveyManagerCase.Persistence.Context;

namespace SurveyManagement.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SurveysController
{
    [HttpPost]
    public IActionResult Create()
    {
        return null;
    }

    [HttpPut("{id}")]
    public IActionResult Update()
    {
        return null;
    }

    [HttpDelete("{id}")]
    public IActionResult Remove()
    {
        return null;
    }

    [HttpGet]
    public IActionResult Get(int id)
    {
        return null;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return GetAll();
    }



}
