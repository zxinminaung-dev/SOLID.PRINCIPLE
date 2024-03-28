using SOLID.PRINCIPLE.Database;
using SOLID.PRINCIPLE.OpenClosePrinciple;
using SOLID.PRINCIPLE.SingleResponsibility.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.PRINCIPLE.SingleResponsibility.Teacher
{
    internal class TeacherFunctions : CrudOperations<TeacherEntity>
    {
        private readonly DatabaseContext dbContext;
        public TeacherFunctions(DatabaseContext context)
        {
            this.dbContext = context;
        }
        public override void Delete(TeacherEntity entity)
        {
            dbContext.Remove(entity);
            dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            dbContext.SaveChanges();
            int id = (int)entity.GetType().GetProperty("id").GetValue(entity);
            Console.WriteLine($"Delete Success");
        }

        public override void GetAll()
        {
            List<StudentEntity> list = dbContext.Student.ToList();
            if (list.Count > 0)
            {
                foreach (var student in list)
                {
                    Console.WriteLine($"Id = {student.id}");
                    Console.WriteLine($"Name = {student.name}");
                }
            }
        }

        public override void GetById(int id)
        {
            StudentEntity student = dbContext.Student.Find(id);
            if (student != null)
            {
                Console.WriteLine($"Id = {student.id}");
                Console.WriteLine($"Name = {student.name}");
            }
        }

        public override void Save(TeacherEntity entity)
        {
            dbContext.Add(entity);
            dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            dbContext.SaveChanges();
            int id = (int)entity.GetType().GetProperty("id").GetValue(entity);
            Console.WriteLine($"Save Success with Id ={id}");
        }

        public override void Update(TeacherEntity entity)
        {
            dbContext.Add(entity);
            dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            int id = (int)entity.GetType().GetProperty("id").GetValue(entity);
            Console.WriteLine($"Update Success with Id = {id}");
        }
    }
}
