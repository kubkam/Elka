using Elka.Core;
using Elka.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Elka.Pages.Courses
{
    public class DetailModel : PageModel
    {
        private readonly ICourseData _courseData;
        public Course Course { get; set; }

        public DetailModel(ICourseData courseData)
        {
            _courseData = courseData;
        }

        public IActionResult OnGet(int courseId)
        {
            Course = _courseData.GetById(courseId);

            if (Course == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}