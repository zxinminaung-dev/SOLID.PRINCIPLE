using SOLID.PRINCIPLE.Database;
using SOLID.PRINCIPLE.SingleResponsibility.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.PRINCIPLE.InterfaceSegregationPriciple
{
    public class TeacherRepository : ITeacherInterface<TeacherEntity>
    {
        private DatabaseContext _dbContext;
        //constructor injection
        //inject the database context
        public TeacherRepository(DatabaseContext databaseContext) 
        { 
            _dbContext = databaseContext;
        }
        public TeacherRepository()
        {
            _dbContext = new DatabaseContext();
        }
        public int delete(TeacherEntity entity)
        {
            int id = 0;
            _dbContext.Remove(entity);
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _dbContext.SaveChanges();
            id = (int)entity.GetType().GetProperty(nameof(entity.id)).GetValue(entity);
            return id;
        }

        public TeacherEntity Get(int id)
        {
            TeacherEntity entity =_dbContext.Teacher.Where(x=> x.id == id).FirstOrDefault();
            return entity;
        }

        public List<TeacherEntity> Get()
        {
            List<TeacherEntity> teacherList = _dbContext.Teacher.ToList();
            return teacherList;
        }

        public void SaveorUpdate(TeacherEntity entity)
        {
            if(entity.id>0)
            {
                _dbContext.Add(entity);
                _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _dbContext.Add(entity);
                _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            _dbContext.SaveChanges ();
        }
    }
}
