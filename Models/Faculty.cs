using System.Collections.Generic;

namespace StudentManagementAPI.Models
{
    public class Faculty
    {
        public int Id {get;set;}
        public string Code {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}

        public List<Course> Courses {get;set;}
    }
}