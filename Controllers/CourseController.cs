using System;
using System.Collections.Generic;
using StudentManagementAPI.Models;
using StudentManagementAPI.DA;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : IController<Course>
    {
        private CourseDF df = new CourseDF();

        [HttpDelete]
        public bool Delete(Course itm)
        {
            return df.Remove(itm);
        }

        [HttpGet("{id}")]
        public Course Get(string id)
        {
            return df.Get(id);
        }

        [HttpGet]
        public List<Course> GetAll()
        {
            return df.GetAll();
        }

        [HttpPost]
        public bool Post(Course itm)
        {
            return df.Add(itm);
        }

        [HttpPut]
        public bool Put(Course itm)
        {
            return df.Update(itm);
        }
    }
}