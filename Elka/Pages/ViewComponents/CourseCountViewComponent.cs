using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elka.Data;
using Microsoft.AspNetCore.Mvc;

namespace Elka.Pages.ViewComponents
{
    public class CourseCountViewComponent
        : ViewComponent
    {
        private readonly ICourseData _courseData;

        public CourseCountViewComponent(ICourseData courseData)
        {
            _courseData = courseData;
        }

        public IViewComponentResult Invoke()
        {
            var count = _courseData.GetCountOfCourse();

            return View(count);
        }
    }
}
