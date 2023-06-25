using Course.API.Shared.Domain.Repositories;
using Course.API.Shared.Persistence.Context;

namespace Course.API.Shared.Persistence.Repositories;

public class UnitOfWork: BaseRepository, IUnitOfWork
{
    public UnitOfWork(AppDbContext context) : base(context)
    {
    }

    public async Task CompleteAsync()
    {
        await Context.SaveChangesAsync();
    }
}