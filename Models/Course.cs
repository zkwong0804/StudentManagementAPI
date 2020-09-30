using System.Collections.Generic;

namespace StudentManagementAPI.Models
{
    public class Course
    {
        public int Id {get;set;}
        public string Code {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public int FacultyID {get;set;}
        public Faculty Faculty {get;set;}
        public List<Student> Students {get;set;}
    }
}