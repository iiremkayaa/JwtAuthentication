using Project.JwtProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Entities.Concrete
{
    public class Product :ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
