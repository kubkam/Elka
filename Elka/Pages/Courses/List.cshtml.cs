﻿using System;
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

        [BindProperty(SupportsGet = true)]
        public int SearchChoice { get; set; }

        public ListModel(ICourseData courseData)
        {
            _courseData = courseData;
        }

        public void OnGet()
        {
            switch (SearchChoice)
            {
                case 0:
                    Courses = _courseData.GetCoursesByName(SearchTerm);
                    break;
                case 1:
                    Courses = _courseData.GetCoursesByMoniker(SearchTerm);
                    break;
                case 2:
                    try
                    {
                        Courses = _courseData.GetCoursesByEcts(SearchTerm);
                    }
                    catch (Exception)
                    {
                        Courses = _courseData.GetCoursesByName("");
                    }
                    break;
                case 3:
                    Courses = _courseData.GetCoursesByTeacherFirstName(SearchTerm);
                    break;
                case 4:
                    Courses = _courseData.GetCoursesByTeacherLastName(SearchTerm);
                    break;
            }
        }
    }
}