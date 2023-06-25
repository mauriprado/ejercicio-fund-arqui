using Course.API.Learning.Domain.Services.Communication;

namespace Course.API.Learning.Domain.Services;

public interface ICourseService
{
    Task<IEnumerable<Models.Course>> ListAsync();
    Task<CourseResponse> GetByIdAsync(int id);
    Task<CourseResponse> SaveAsync(Models.Course course);
    Task<CourseResponse> UpdateAsync(int id, Models.Course course);
    Task<CourseResponse> DeleteAsync(int id);
}