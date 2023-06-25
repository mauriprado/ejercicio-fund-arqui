using Course.API.Shared.Domain.Services.Communication;

namespace Course.API.Learning.Domain.Services.Communication;

public class CourseResponse: BaseResponse<Models.Course>
{
    public CourseResponse(string message) : base(message)
    {
    }

    public CourseResponse(Models.Course resource) : base(resource)
    {
    }
}