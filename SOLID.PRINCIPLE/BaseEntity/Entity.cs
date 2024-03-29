using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.PRINCIPLE.BaseEntity
{
    public class Entity
    {
        public int id { get; set; }
        public virtual int getId()
        {
            return 1;
        }
    }
}
