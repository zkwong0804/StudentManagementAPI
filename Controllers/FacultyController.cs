using System;
using StudentManagementAPI.Models;
using StudentManagementAPI.DA;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/faculty")]
    public class FacultyController : IController<Faculty>
    {

        private FacultyDF df = new FacultyDF();

        [HttpDelete]
        public bool Delete(Faculty itm)
        {
            Console.WriteLine("Faculty:DELETE");
            return df.Remove(itm);
        }

        [HttpGet("{id}")]
        public Faculty Get(string id)
        {
            Console.WriteLine("Faculty:GET:Single");
            return df.Get(id);
        }

        [HttpGet]
        public List<Faculty> GetAll()
        {
            Console.WriteLine("Faculty:GET:All");
            return df.GetAll();
        }


        [HttpPost]
        public bool Post(Faculty itm)
        {
            Console.WriteLine("Faculty:ADD");
            return df.Add(itm);
        }

        [HttpPut]
        public bool Put(Faculty itm)
        {
            Console.WriteLine("Faculty:PUT");
            return df.Update(itm);
        }
    }
}