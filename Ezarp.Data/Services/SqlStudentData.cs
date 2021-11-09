using Ezarp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ezarp.Data.Services
{
    public class SqlStudentData : IStudentData
    {
        private readonly EzarpDbContext db;

        public SqlStudentData(EzarpDbContext db)
        {
            this.db = db;
        }
        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
        }

        public Student Get(int id)
        {
            return db.Students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students.OrderBy(s => s.Name);
        }

        public void Update(Student student)
        {
            var entry = db.Entry(student);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}