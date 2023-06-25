namespace Course.API.Learning.Domain.Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<Models.Course>> ListAsync();
    Task<Models.Course> FindByIdAsync(int id);
    Task AddAsync(Models.Course course);
    void Update(Models.Course course);
    void Remove(Models.Course course);
}