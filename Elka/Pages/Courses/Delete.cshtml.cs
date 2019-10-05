using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elka.Core;
using Elka.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Elka.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseData _courseData;
        public Course Course { get; set; }

        public DeleteModel(ICourseData courseData)
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

        public IActionResult OnPost(int courseId)
        {
            var course = _courseData.Delete(courseId);
            _courseData.Commit();

            if (course == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{course.Name} deleted";

            return RedirectToPage("./List");
        }
    }
}