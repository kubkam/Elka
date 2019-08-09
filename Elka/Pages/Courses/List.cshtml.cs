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
    public class ListModel : PageModel
    {
        private readonly ICourseData _courseData;
        public IEnumerable<Course> Courses { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(ICourseData courseData)
        {
            _courseData = courseData;
        }

        public void OnGet()
        {

            Courses = _courseData.GetCoursesByName(SearchTerm);

        }
    }
}