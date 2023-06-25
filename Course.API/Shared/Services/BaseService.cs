using Course.API.Shared.Domain.Repositories;

namespace Course.API.Shared.Services;

public abstract class BaseService
{
    protected readonly IUnitOfWork UnitOfWork;

    protected BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}