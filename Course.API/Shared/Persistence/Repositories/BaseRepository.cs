using Course.API.Shared.Persistence.Context;

namespace Course.API.Shared.Persistence.Repositories;

public abstract class BaseRepository
{
    protected readonly AppDbContext Context;

    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }
}