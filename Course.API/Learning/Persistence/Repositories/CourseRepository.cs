using Course.API.Learning.Domain.Repositories;
using Course.API.Shared.Persistence.Context;
using Course.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Course.API.Learning.Persistence.Repositories;

public class CourseRepository: BaseRepository, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.Course>> ListAsync()
    {
        return await Context.Courses.ToListAsync();
    }

    public async Task<Domain.Models.Course> FindByIdAsync(int id)
    {
        return await Context.Courses.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Domain.Models.Course course)
    {
        await Context.Courses.AddAsync(course);
    }

    public void Update(Domain.Models.Course course)
    {
        Context.Courses.Update(course);
    }

    public void Remove(Domain.Models.Course course)
    {
        Context.Courses.Remove(course);
    }
}