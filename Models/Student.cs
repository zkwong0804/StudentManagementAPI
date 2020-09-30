using StudentManagementAPI.DA;
namespace StudentManagementAPI.Models
{
    public class Student
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public int IntakeYear {get;set;}
        public int CourseID {get;set;}
        public Course Course {get;set;}
    }
}