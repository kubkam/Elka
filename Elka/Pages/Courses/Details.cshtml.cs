using Elka.Core;
using Elka.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Elka.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ICourseData _courseData;
        public Course Course { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailsModel(ICourseData courseData)
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