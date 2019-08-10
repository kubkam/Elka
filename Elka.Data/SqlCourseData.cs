﻿using System.Collections.Generic;
using System.Linq;
using Elka.Core;
using Microsoft.EntityFrameworkCore;

namespace Elka.Data
{
    public class SqlCourseData : ICourseData
    {
        private readonly ElkaDbContext _db;

        public SqlCourseData(ElkaDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Course> GetCoursesByName(string name)
        {
            var query = _db.Courses
                .Include(c => c.Teacher)
                .Where(c => string.IsNullOrEmpty(name) || c.Name.Contains(name))
                .OrderBy(c => c.Name);
            
            return query;
        }

        public Course GetById(int id)
        {
            return _db.Courses
                .Include(c => c.Teacher)
                .FirstOrDefault(c => c.Id == id);
        }

        public Course Update(Course updatedCourse)
        {
            _db.Entry(updatedCourse.Teacher).State = EntityState.Modified;

            return updatedCourse;
        }

        public Course Add(Course newCourse)
        {
            _db.Add(newCourse);

            return newCourse;
        }

        public Course Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                _db.Courses.Remove(course);
            }

            return course;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}