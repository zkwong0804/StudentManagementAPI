using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.DA
{
    public class FacultyDF : IDataFactory<Faculty>
    {
        public bool Add(Faculty itm)
        {
            try
            {
                Console.WriteLine(
                    $"Attempting to add new faculty ({itm.Code})"
                );
                using (var db = new StudentContext())
                {
                    db.Faculties.Add(itm);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Failed to add new Faculty ({itm.Code}) [{ex.Message}]"
                );

                return false;
            }

            return true;
        }

        public Faculty Get(string id)
        {
            Console.WriteLine(
                $"Attempting to get Faculty ({id})"
            );

            Faculty Faculty = null;
            try
            {
                using (var db = new StudentContext())
                {
                    Faculty = db.Faculties.Single(i => i.Id == Int32.Parse(id));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Failed to get Faculty ({id}) [{ex.Message}]"
                );
            }

            return Faculty;
        }

        public List<Faculty> GetAll()
        {
            Console.WriteLine($"Attempting to get all faculties");
            List<Faculty> faculties = null;

            try
            {
                using(var db = new StudentContext())
                {
                    faculties = db.Faculties.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get all faculties [{ex.Message}]");
            }

            return faculties;
        }

        public bool Remove(Faculty itm)
        {
            Console.WriteLine($"Attempting to remove Faculty ({itm.Code})");

            try
            {
                using(var db = new StudentContext())
                {
                    db.Faculties.Remove(itm);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to remove Faculty ({itm.Code}) [{ex.Message}]");
                return false;
            }

            return true;
        }

        public int Total()
        {
            Console.WriteLine($"Attempting to get faculties total");

            int total = 0;

            try
            {
                using(var db = new StudentContext())
                {
                    total = db.Faculties.Count();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get faculties total [{ex.Message}]");
            }

            return total;
        }

        public bool Update(Faculty itm)
        {
            Console.WriteLine($"Attempting to update Faculty ({itm.Code})");

            try
            {
                using(var db = new StudentContext())
                {
                    db.Faculties.Update(itm);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update Faculty ({itm.Code}) [{ex.Message}]");
                return false;
            }

            return true;
        }
    }
}