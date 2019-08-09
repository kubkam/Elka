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
    public class EditModel : PageModel
    {
        private readonly ICourseData _courseData;

        [BindProperty]
        public Course Course { get; set; }

        public EditModel(ICourseData courseData)
        {
            _courseData = courseData;
        }

        public IActionResult OnGet(int? courseId)
        {
            if (courseId.HasValue)
            {
                Course = _courseData.GetById(courseId.Value);
            }
            else
            {
                Course = new Course {Teacher = new Teacher()};

            }
            
            if (Course == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Course.Id > 0)
            {
                _courseData.Update(Course);
                TempData["Message"] = "Course updated";
            }
            else
            {
                _courseData.Add(Course);
                TempData["Message"] = "Course created";
            }
            _courseData.Commit();

            return RedirectToPage("./Detail", new {courseId = Course.Id});
        }
    }
}