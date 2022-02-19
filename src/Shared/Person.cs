using BlazorMultiLanguageCourse.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace BlazorMultiLanguageCourse.Shared
{
    public class Person
    {
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.required))]
        public string Name { get; set; } = "";
    }
}
