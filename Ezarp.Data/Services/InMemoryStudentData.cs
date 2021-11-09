using Ezarp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ezarp.Data.Services
{
    public class InMemoryStudentData : IStudentData
    {
        private List<Student> students;
        public InMemoryStudentData()
        {
            students = new List<Student>
            {
                new Student { Id = 1, Name = "Miles", Grade = Grade.Twelfth, AverageGrade = 9.5 },
                new Student { Id = 2, Name = "Peter", Grade = Grade.Eleventh, AverageGrade = 9.9 },
                new Student { Id = 3, Name = "Gwen", Grade = Grade.Tenth, AverageGrade = 8.6 },
            };
        }
        public IEnumerable<Student> GetAll()
        {
            return students.OrderBy(s => s.Name);
        }
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            students.Add(student);
        }
        public void Update(Student student)
        {
            var temp = Get(student.Id);
            temp.Name = student.Name;
            temp.Grade = student.Grade;
            temp.AverageGrade = student.AverageGrade;
        }

        public void Delete(int id)
        {
            var student = Get(id);
            if (student != null)
            {
                students.Remove(student);
            }
        }
    }
}