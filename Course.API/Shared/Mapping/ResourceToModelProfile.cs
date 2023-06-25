using AutoMapper;
using Course.API.Learning.Resources;

namespace Course.API.Shared.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCourseResource, Learning.Domain.Models.Course>();
    }
}