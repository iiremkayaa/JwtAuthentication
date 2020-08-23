using Project.JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.Business.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(AppUser appUser, List<AppRole> roles);
    }
}
