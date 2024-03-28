using SOLID.PRINCIPLE.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.PRINCIPLE.SingleResponsibility.Student
{
    //a class must have only one reason to change
    internal class StudentEntity : Entity
    {
        public string name { get; set; }
        //liskov substitution principle
        // Method Overriding
        public override int getId() 
        { 
            return this.id;
        }
    }
}
