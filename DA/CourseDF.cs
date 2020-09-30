using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.DA
{
    public class CourseDF : IDataFactory<Course>
    {
        public bool Add(Course itm)
        {
            try
            {
                Console.WriteLine(
                    $"Attempting to add new course ({itm.Code})"
                );
                using (var db = new StudentContext())
                {
                    db.Courses.Add(itm);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Failed to add new course ({itm.Code}) [{ex.Message}]"
                );

                return false;
            }

            return true;
        }

        public Course Get(string id)
        {
            Console.WriteLine(
                $"Attempting to get course ({id})"
            );

            Course course = null;
            try
            {
                using (var db = new StudentContext())
                {
                    course = db.Courses.Single(i => i.Code == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Failed to get course ({id}) [{ex.Message}]"
                );
            }

            return course;
        }

        public List<Course> GetAll()
        {
            Console.WriteLine($"Attempting to get all courses");
            List<Course> courses = null;

            try
            {
                using(var db = new StudentContext())
                {
                    courses = db.Courses.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get all courses [{ex.Message}]");
            }

            return courses;
        }

        public bool Remove(Course itm)
        {
            Console.WriteLine($"Attempting to remove course ({itm.Code})");

            try
            {
                using(var db = new StudentContext())
                {
                    db.Courses.Remove(itm);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to remove course ({itm.Code}) [{ex.Message}]");
                return false;
            }

            return true;
        }

        public int Total()
        {
            Console.WriteLine($"Attempting to get courses total");

            int total = 0;

            try
            {
                using(var db = new StudentContext())
                {
                    total = db.Courses.Count();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get courses total [{ex.Message}]");
            }

            return total;
        }

        public bool Update(Course itm)
        {
            Console.WriteLine($"Attempting to update course ({itm.Code})");

            try
            {
                using(var db = new StudentContext())
                {
                    db.Courses.Update(itm);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update course ({itm.Code}) [{ex.Message}]");
                return false;
            }

            return true;
        }
    }
}