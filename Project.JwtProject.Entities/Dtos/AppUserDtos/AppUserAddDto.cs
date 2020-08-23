using Project.JwtProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Entities.Dtos.AppUserDtos
{
    public class AppUserAddDto :IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
