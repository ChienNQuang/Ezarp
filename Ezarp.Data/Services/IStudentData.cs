using Ezarp.Data.Models;
using System.Collections.Generic;

namespace Ezarp.Data.Services
{
    public interface IStudentData
    {
        Student Get(int id);
        IEnumerable<Student> GetAll();
        void Add(Student student);
        void Delete(int id);
        void Update(Student student);
    }
}