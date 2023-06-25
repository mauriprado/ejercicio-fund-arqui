using System.ComponentModel.DataAnnotations;

namespace Course.API.Learning.Resources;

public class SaveCourseResource
{
    [Required]
    public string Name { set; get; }
    
    [Required]
    public Double Price { set; get; }
}