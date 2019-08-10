using System;
using System.Collections.Generic;
using System.Text;
using Elka.Core;

namespace Elka.Data
{
    public interface ICourseData
    {
        IEnumerable<Course> GetCoursesByName(string name);
        Course GetById(int id);
        Course Update(Course updatedCourse);
        Course Add(Course newCourse);
        Course Delete(int id);
        int Commit();
    }
}
