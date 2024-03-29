using SOLID.PRINCIPLE.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.PRINCIPLE.InterfaceSegregationPriciple
{
    public interface ITeacherInterface<TEntity> where TEntity : Entity, new()
    {
        void SaveorUpdate(TEntity entity);
        int delete(TEntity entity);
        TEntity Get(int id);
        List<TEntity> Get();

    }
}
