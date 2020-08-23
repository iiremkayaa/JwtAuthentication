using Project.JwtProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Entities.Dtos.AppUserDtos
{
    public class AppUserLoginDto :IDto
    {
        public string UserName { get;set; }
        public string Password { get; set; }
    }
}
