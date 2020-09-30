using System.Collections.Generic;
using StudentManagementAPI.Models;
using System;
using System.Linq;

namespace StudentManagementAPI.DA
{
    public class StudentDF : IDataFactory<Student>
    {
        public bool Add(Student itm)
        {
            try
            {
                using (var db = new StudentContext())
                {
                    Console.WriteLine($"Attempting to add new student ({itm.Name})");
                    Course c = db.Courses.Single(c => c.Id == itm.CourseID);
                    itm.Id = String.Format(
                        "{0}{1}", 
                        c.Code, 
                        (db.Students.Count()+1000)
                    );
                    Console.WriteLine($"Stud ID: {itm.Id}");
                    db.Students.Add(itm);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add new student ({itm.Id}) [{ex.Message}]");
                return false;
            }

            return true;
        }

        public List<Student> GetAll()
        {
            List<Student> students = null;
            try
            {
                using (var db = new StudentContext())
                {
                    Console.WriteLine("Attempting to get all students");
                    students = db.Students.ToList<Student>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get all students [{ex.Message}]");
            }

            return students;
        }

        public List<Student> GetAllByFaculty(string fid)
        {
            List<Student> students = null;
            try
            {
                using (var db = new StudentContext())
                {
                    Console.WriteLine($"Attempting to get all students by faculty({fid})");
                    students = db.Students
                    .Where(s => s.Course.Faculty.Code == fid)
                    .ToList<Student>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Failed to get students from faculty({fid}) [{ex.Message}]"
                );
            }

            return students;
        }
        public List<Student> GetAllByCourse(string cid)
        {
            List<Student> students = null;
            try
            {
                using (var db = new StudentContext())
                {
                    Console.WriteLine($"Attempting to get all students by faculty({cid})");
                    students = db.Students
                    .Where(s => s.Course.Code == cid)
                    .ToList<Student>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Failed to get students from course({cid}) [{ex.Message}]"
                );
            }

            return students;
        }
        public List<Student> GetAllByIntakeYear(int year)
        {
            List<Student> students = null;
            try
            {
                using (var db = new StudentContext())
                {
                    Console.WriteLine($"Attempting to get all students from year {year}");
                    students = db.Students
                    .Where(s => s.IntakeYear == year)
                    .ToList<Student>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Failed to get students from year {year} [{ex.Message}]"
                );
            }

            return students;
        }

        public bool Remove(Student itm)
        {
            try
            {
                using (var db = new StudentContext())
                {
                    db.Students.Remove(itm);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to remove student({itm.Id}) [{ex.Message}]");
                return false;
            }

            return true;
        }

        public bool Update(Student itm)
        {
            try
            {
                using (var db = new StudentContext())
                {
                    db.Students.Update(itm);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update student ({itm.Id}) [{ex.Message}]");
                return false;
            }

            return true;
        }

        public Student Get(string id)
        {
            Student student = null;

            try
            {
                using (var db = new StudentContext())
                {
                    Console.WriteLine($"Attempting to get student({id})");
                    student = db.Students.Single(s => s.Id == id);
                }
            }
            catch (Exception ex)
            {
                    Console.WriteLine($"Failed to get student({id}) [{ex.Message}]");
            }
            return student;
        }

        public int Total()
        {
            int total = 0;

            try
            {
                using (var db = new StudentContext())
                {
                    total = db.Students.Count();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to get total record of students [{ex.Message}]");
            }

            return total;
        }
    }
}