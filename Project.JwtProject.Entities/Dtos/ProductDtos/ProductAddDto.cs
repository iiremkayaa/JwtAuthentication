using Project.JwtProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Entities.Dtos.ProductDtos
{
    public class ProductAddDto :IDto
    {
        public string Name { get; set; }
    }
}
