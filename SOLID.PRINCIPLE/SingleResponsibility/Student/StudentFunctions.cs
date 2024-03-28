using SOLID.PRINCIPLE.Database;
using SOLID.PRINCIPLE.OpenClosePrinciple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SOLID.PRINCIPLE.SingleResponsibility.Student
{
    internal class StudentFunctions : CrudOperations<StudentEntity>
    {
        private readonly DatabaseContext dbContext;
        public StudentFunctions(DatabaseContext context) 
        {
            this.dbContext = context;
        } 
        public override void Delete(StudentEntity entity)
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
            if(list.Count > 0)
            {
                foreach(var student in list) 
                {
                    Console.WriteLine($"Id = {student.id}");
                    Console.WriteLine($"Name = {student.name}");
                }
            }
            else
            {
                Console.WriteLine("There is no data in student table");
            }
        }

        public override void GetById(int id)
        {
            StudentEntity student = dbContext.Student.Find(id); 
            if(student!=null)
            {
                Console.WriteLine($"Id = {student.id}");
                Console.WriteLine($"Name = {student.name}");
            }
        }

        public override void Save(StudentEntity entity)
        {
            dbContext.Add(entity);
            dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            dbContext.SaveChanges();
            int id = (int)entity.GetType().GetProperty("id").GetValue(entity);
            Console.WriteLine($"Save Success with Id ={id}");
        }

        public override void Update(StudentEntity entity)
        {
            dbContext.Add(entity);
            dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            int id = (int)entity.GetType().GetProperty("id").GetValue(entity);
            Console.WriteLine($"Update Success with Id = {id}");
        }
    }
}
