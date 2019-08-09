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

        public IActionResult OnGet(int courseId)
        {
            Course = _courseData.GetById(courseId);

            if (Course == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _courseData.Update(Course);
                _courseData.Commit();
            }
            
            return Page();
        }
    }
}