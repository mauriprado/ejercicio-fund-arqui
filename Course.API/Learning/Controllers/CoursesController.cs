using AutoMapper;
using Course.API.Learning.Domain.Services;
using Course.API.Learning.Resources;
using Course.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Course.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CoursesController: ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;

    public CoursesController(ICourseService courseService, IMapper mapper)
    {
        _courseService = courseService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<Domain.Models.Course>> GetAllAsync()
    {
        var courses = await _courseService.ListAsync();
        return courses;
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _courseService.GetByIdAsync(id);
        
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Resource);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCourseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var course = _mapper.Map<SaveCourseResource, Domain.Models.Course>(resource);
        var result = await _courseService.SaveAsync(course);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Resource);
    }

    [HttpPut("id")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCourseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var course = _mapper.Map<SaveCourseResource, Domain.Models.Course>(resource);
        var result = await _courseService.UpdateAsync(id, course);
        
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Resource);
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
       var result = await _courseService.DeleteAsync(id);
       
       if (!result.Success)
       {
           return BadRequest(result.Message);
       }

       return Ok(result.Resource);
    }
}