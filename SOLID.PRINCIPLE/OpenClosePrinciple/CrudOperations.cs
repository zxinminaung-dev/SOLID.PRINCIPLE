using SOLID.PRINCIPLE.BaseEntity;
using SOLID.PRINCIPLE.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.PRINCIPLE.OpenClosePrinciple
{
    //Generic class
    internal abstract class CrudOperations<TEntity> where TEntity : Entity, new()
    {
        //abstract methods 
        //method without body
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void GetAll();
       public abstract void GetById(int id);
        public abstract void Delete(TEntity entity);
        //concrete method
        //method with body
        public void SaveOrUpdate(TEntity entity)
        {
            using (var context = new DatabaseContext())
            {
                context.Add(entity);
                if (entity.id > 0)
                {
                    context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                context.SaveChanges();
                int id =(int)entity.GetType().GetProperty(nameof(entity.id)).GetValue(entity);  
                Console.WriteLine($"Save or Update Complete with Id = {id}");
            }
        }
    }
}
