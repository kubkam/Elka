using System;
using System.Collections.Generic;
using System.Linq;
using Elka.Core;

namespace Elka.Data
{
    public class InMemoryCourseData : ICourseData
    {
        private readonly List<Course> courses;

        public InMemoryCourseData()
        {
            courses = new List<Course>()
            {
                new Course { Id = 1, Name = "Cyfrowe przetwarzanie sygnałów", Moniker  = "CYPS", HowEasy = 100, InterestingLevel = 50,
                    Teacher = new Teacher{ Id = 1, FirstName = "Zbigniew", LastName = "Gajo"}, Descriptions = "Latwy", ECTS = 2},
                new Course { Id = 2, Name = "Elementy i uklady elektroniczne", Moniker  = "ELIU", HowEasy = 50, InterestingLevel = 10,
                    Teacher = new Teacher{ Id = 2, FirstName = "Krzysztof", LastName = "Czuba"}, Descriptions = "Trudny", ECTS = 5},
                new Course { Id = 3, Name = "Podstawy Radiokomunikacji", Moniker  = "PR", HowEasy = 75, InterestingLevel = 30,
                    Teacher = new Teacher{ Id = 3, FirstName = "Jacek", LastName = "Cichocki"}, Descriptions = "Sredni", ECTS = 3}
            };
        }

        public IEnumerable<Course> GetCoursesByName(string name)
        {
            return courses
                .Where(c => string.IsNullOrEmpty(name) || c.Name.Contains(name))
                .OrderBy(c => c.Name);
        }

        public IEnumerable<Course> GetCoursesByTeacherFirstName(string name)
        {
            return courses
                .Where(t => string.IsNullOrEmpty(name) || t.Teacher.FirstName.Contains(name))
                .OrderBy(t => t.Teacher.FirstName);
        }

        public IEnumerable<Course> GetCoursesByTeacherLastName(string name)
        {
            return courses
                .Where(t => string.IsNullOrEmpty(name) || t.Teacher.LastName.Contains(name))
                .OrderBy(t => t.Teacher.LastName);
        }

        public IEnumerable<Course> GetCoursesByEcts(string ects)
        {
           var _ects = int.Parse(ects);

            return courses
                .Where(c => c.ECTS == _ects)
                .OrderBy(c => c.Name);
        }

        public IEnumerable<Course> GetCoursesByMoniker(string moniker)
        {
            return courses
                .Where(c => string.IsNullOrEmpty(moniker) || c.Moniker.Contains(moniker))
                .OrderBy(c => c.Name);
        }

        public Course GetById(int id)
        {
            return courses.FirstOrDefault(c => c.Id == id);
        }

        public Course Update(Course updatedCourse)
        {
            var course = courses.FirstOrDefault(c => c.Id == updatedCourse.Id);
            if (course != null)
            {
                course.Name = updatedCourse.Name;
                course.Moniker = updatedCourse.Moniker;
                course.InterestingLevel = updatedCourse.InterestingLevel;
                course.HowEasy = updatedCourse.HowEasy;
                course.Descriptions = updatedCourse.Descriptions;
                course.ECTS = updatedCourse.ECTS;
                course.Teacher.FirstName = updatedCourse.Teacher.FirstName;
                course.Teacher.LastName = updatedCourse.Teacher.LastName;
            }

            return course;
        }

        public Course Add(Course newCourse)
        {
            courses.Add(newCourse);
            newCourse.Id = courses.Max(c => c.Id) + 1;
            newCourse.Teacher.Id = courses.Max(t => t.Teacher.Id) + 1;

            return newCourse;
        }

        public Course Delete(int id)
        {
            var course = courses.SingleOrDefault(c => c.Id == id);
            if (course != null)
            {
                courses.Remove(course);
            }

            return course;
        }

        public int Commit()
        {
            return 0;
        }

        public int GetCountOfCourse()
        {
            return courses.Count();
        }
    }
}