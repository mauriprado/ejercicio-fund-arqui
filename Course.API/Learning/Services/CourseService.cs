using Course.API.Learning.Domain.Repositories;
using Course.API.Learning.Domain.Services;
using Course.API.Learning.Domain.Services.Communication;
using Course.API.Shared.Domain.Repositories;
using Course.API.Shared.Services;

namespace Course.API.Learning.Services;

public class CourseService: BaseService, ICourseService
{
    private readonly ICourseRepository _courseRepository;
    
    public CourseService(IUnitOfWork unitOfWork, ICourseRepository courseRepository) : base(unitOfWork)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IEnumerable<Domain.Models.Course>> ListAsync()
    {
        return await _courseRepository.ListAsync();
    }

    public async Task<CourseResponse> GetByIdAsync(int id)
    {
        var course = await _courseRepository.FindByIdAsync(id);
        if (course == null)
        {
            return new CourseResponse("Invalid course");
        }
        return new CourseResponse(course);
    }

    public async Task<CourseResponse> SaveAsync(Domain.Models.Course course)
    {
        try
        {
            await _courseRepository.AddAsync(course);
            await UnitOfWork.CompleteAsync();
            return new CourseResponse(course);
        }
        catch (Exception e)
        {
            return new CourseResponse($"An error occurred while saving course: {e.Message}");
        }
    }

    public async Task<CourseResponse> UpdateAsync(int id, Domain.Models.Course course)
    {
        var existingCourse = await _courseRepository.FindByIdAsync(id);
        if (existingCourse == null)
        {
            return new CourseResponse("Invalid course");
        }

        existingCourse.Name = course.Name;
        existingCourse.Price = course.Price;
        
        try
        {
            _courseRepository.Update(existingCourse);
            await UnitOfWork.CompleteAsync();
            return new CourseResponse(existingCourse);
        }
        catch (Exception e)
        {
            return new CourseResponse($"An error occurred while updating course: {e.Message}");
        }
    }

    public async Task<CourseResponse> DeleteAsync(int id)
    {
        var existingCourse = await _courseRepository.FindByIdAsync(id);
        if (existingCourse == null)
        {
            return new CourseResponse("Invalid course");
        }
        
        try
        {
            _courseRepository.Remove(existingCourse);
            await UnitOfWork.CompleteAsync();
            return new CourseResponse(existingCourse);
        }
        catch (Exception e)
        {
            return new CourseResponse($"An error occurred while deleting course: {e.Message}");
        }
    }
}