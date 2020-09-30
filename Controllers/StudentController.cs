using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.DA;
using System;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : IController<Student>
    {
        StudentDF df = new StudentDF();

        [HttpDelete]
        public bool Delete(Student student)
        {
            Console.WriteLine("DELETE");
            return df.Remove(student);
        }

        [HttpGet("{id}")]
        public Student Get(string id)
        {
            Console.WriteLine("GET: Single");
            return df.Get(id);
        }

        [HttpGet]
        public List<Student> GetAll()
        {
            Console.WriteLine("GET: All");
            return df.GetAll();
        }

        [HttpGet("faculty/{fid}")]
        public List<Student> GetAllByFaculty(string fid)
        {
            Console.WriteLine("GET: By Faculty");
            return df.GetAllByFaculty(fid);
        }

        [HttpGet("course/{cid}")]
        public List<Student> GetAllByCourse(string cid)
        {
            Console.WriteLine("GET: By Course");
            return df.GetAllByCourse(cid);
        }

        [HttpPost]
        public bool Post(Student student)
        {
            Console.WriteLine("POST");
            return df.Add(student);
        }

        [HttpPut]
        public bool Put(Student student)
        {
            Console.WriteLine("PUT");
            return df.Update(student);
        }
    }
}