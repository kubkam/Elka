using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elka.Core;

namespace Elka.Data
{
    public interface ICourseData
    {
        IEnumerable<Course> GetCoursesByName(string name);
        Course GetById(int id);
        Course Update(Course updatedCourse);
        int Commit();
    }

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

        public int Commit()
        {
            return 0;
        }
    }

}
